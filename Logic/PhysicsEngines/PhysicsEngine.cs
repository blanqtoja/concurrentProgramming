using System;
using System.Collections.Generic;
using Data;
using Data.Ball;
using Data.Table;

namespace Logic.PhysicsEngines
{
    public class PhysicsEngine : IPhysicsEngine
    {
        private readonly List<IBall> _balls = new List<IBall>(); // lista do odczytu

        public IReadOnlyList<IBall> Balls => _balls.AsReadOnly(); // zwracamy liste tylko do odczytu
        public ITable Table { get; } // tylko do odczytu, hermetyzajca

        public PhysicsEngine(Table table, IEnumerable<IBall> balls)
        {
            Table = table;
            _balls.AddRange(balls);
        }

        public void AddBall(IBall ball)
        {
            _balls.Add(ball);
        }

        public void RemoveBall(int id)
        {
            // najpierw znajdujemy kule
            IBall ball = _balls.Find(b => b.Id == id);
            if (ball != null)
            {
                _balls.Remove(ball);
            }
        }

        public bool IsBallsCollide(int id1, int id2)
        {
            IBall ball1 = _balls.Find(b => b.Id == id1);
            IBall ball2 = _balls.Find(b => b.Id == id2);
            if (ball1 == null || ball2 == null) return false;

            // liczymy odleglosc od srodkow obu kul, wykorzystujemy wzor Pitagorasa
            double distance = Math.Sqrt(Math.Pow(ball1.X - ball2.X, 2) + Math.Pow(ball1.Y - ball2.Y, 2));

            // sprawdzamy czy odleglosc jest mniejsza od sumy promieni kul
            return distance <= (ball1.Radius + ball2.Radius);
        }

        public bool IsBallCollideHorizontalBand(IBall ball)
        {

            if (ball == null) return false;

            // czy pozycja kuli + jej promien sa mniejsze od 0 lub wieksze od wysokosci stolu
            if(ball.Y - ball.Radius < 0 || ball.Y + ball.Radius > Table.Hight)
            {
                return true;
            }

            return false;

        }
        public bool IsBallCollideVerticalBand(IBall ball)
        {
            if (ball == null) return false;

            // czy pozycja kuli + jej promien sa mniejsze od 0 lub wieksze od szerokosci stolu
            if (ball.X - ball.Radius < 0 || ball.X + ball.Radius > Table.Width)
            {
                return true;
            }

            return false;

        }
        private void UpdateBallPosition(IBall ball)
        {
            //IBall ball = findBall(id);

            if (ball == null) return;

            ball.X += ball.VelocityX;
            ball.Y += ball.VelocityY;

            HandleCollisions(ball);
        }

        //private IBall findBall(int id)
        //{
        //    return _balls.Find(b => b.Id == id);
        //}

        private void HandleCollisions(IBall ball)
        {
            if(ball == null) return;

            // z prawa zachowania pedu
            if (IsBallCollideHorizontalBand(ball))
            {
                ball.VelocityX = -ball.VelocityX;
            }
            if (IsBallCollideVerticalBand(ball))
            {
                ball.VelocityY = -ball.VelocityY;
            }
        }


        // ruch wszystkich kul
        public void MoveBalls()
        {
            foreach (IBall ball in _balls)
            {
                UpdateBallPosition(ball);
            }
        }
    }
}
