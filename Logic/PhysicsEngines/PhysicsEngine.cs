using System;
using System.Collections.Generic;
using Data;
using Data.Ball;
using Data.Table;
using Logic.BallLogic;

namespace Logic.PhysicsEngines
{
    public class PhysicsEngine : IPhysicsEngine
    {
        private IDataAPI _dataAPI;

        private readonly List<SingleBallLogic> _balls = new List<SingleBallLogic>(); // lista do odczytu

        public IReadOnlyList<SingleBallLogic> Balls => _balls.AsReadOnly(); // zwracamy liste tylko do odczytu
        public ITable Table { get; } // tylko do odczytu, hermetyzajca

        IReadOnlyList<IBall> IPhysicsEngine.Balls => throw new NotImplementedException();

        public PhysicsEngine(ITable table, IEnumerable<IBall> balls)
        {
            Table = table;

            // dodajemy kule do silnika fizycznego
            foreach (IBall ball in balls)
            {
                _balls.Add(new SingleBallLogic(ball, table));
            }
        }

        //public PhysicsEngine(IDataAPI dataAPI)
        //{
        //    _dataAPI = dataAPI;

        //    // dodajemy kule do silnika fizycznego
        //    foreach (IBall ball in balls)
        //    {
        //        _balls.Add(new SingleBallLogic(ball, table));
        //    }
        //}

        public void AddBall(IBall ball)
        {
            _balls.Add(new SingleBallLogic(ball, this.Table));
        }

        public void AddBall(SingleBallLogic ball)
        {
            _balls.Add(ball);
        }

        public void RemoveBall(int id)
        {
            // najpierw znajdujemy kule
            SingleBallLogic ball = _balls.Find(b => b.BallData.Id == id);
            if (ball != null)
            {
                _balls.Remove(ball);
            }
        }

        public bool IsBallsCollide(int id1, int id2)
        {
            SingleBallLogic ball1 = _balls.Find(b => b.BallData.Id == id1);
            SingleBallLogic ball2 = _balls.Find(b => b.BallData.Id == id2);
            if (ball1 == null || ball2 == null) return false;

            // liczymy odleglosc od srodkow obu kul, wykorzystujemy wzor Pitagorasa
            double distance = Math.Sqrt(Math.Pow(ball1.BallData.X - ball2.BallData.X, 2) + Math.Pow(ball1.BallData.Y - ball2.BallData.Y, 2));

            // sprawdzamy czy odleglosc jest mniejsza od sumy promieni kul
            return distance <= (ball1.BallData.Radius + ball2.BallData.Radius);
        }

        public bool IsBallCollideHorizontalBand(SingleBallLogic ball)
        {

            if (ball == null) return false;

            // czy pozycja kuli + jej promien sa mniejsze od 0 lub wieksze od wysokosci stolu
            if(ball.BallData.Y - ball.BallData.Radius < 0 || ball.BallData.Y + ball.BallData.Radius > Table.Height)
            {
                return true;
            }

            return false;

        }
        public bool IsBallCollideVerticalBand(SingleBallLogic ball)
        {
            if (ball == null) return false;

            // czy pozycja kuli + jej promien sa mniejsze od 0 lub wieksze od szerokosci stolu
            if (ball.BallData.X - ball.BallData.Radius < 0 || ball.BallData.X + ball.BallData.Radius > Table.Width)
            {
                return true;
            }

            return false;

        }
        private void UpdateBallPosition(SingleBallLogic ball)
        {
            //IBall ball = findBall(id);

            if (ball == null) return;

            ball.BallData.X += ball.BallData.VelocityX;
            ball.BallData.Y += ball.BallData.VelocityY;

            HandleCollisions(ball);
        }

        //private IBall findBall(int id)
        //{
        //    return _balls.Find(b => b.Id == id);
        //}

        private void HandleCollisions(SingleBallLogic ball)
        {
            if(ball == null) return;

            // z prawa zachowania pedu
            if (IsBallCollideHorizontalBand(ball))
            {
                ball.BallData.VelocityX = -ball.BallData.VelocityX;
            }
            if (IsBallCollideVerticalBand(ball))
            {
                ball.BallData.VelocityY = -ball.BallData.VelocityY;
            }
        }


        // ruch wszystkich kul
        public void MoveBalls()
        {
            foreach (SingleBallLogic ball in _balls)
            {
                UpdateBallPosition(ball);
            }
        }

        public bool IsBallCollideHorizontalBand(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsBallCollideVerticalBand(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBallPosition(IBall ball)
        {
            throw new NotImplementedException();
        }
    }
}
