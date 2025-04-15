using System;
using System.Collections.Generic;
using System.ComponentModel;
using Data;
using Data.Ball;
using Data.Table;
using Logic.BallLogic;

namespace Logic.PhysicsEngines
{
    public class PhysicsEngine : IPhysicsEngine
    {
        private IDataAPI _dataAPI;

        // sprawdzic czy nie bedize nullem
        public List<SingleBallLogic> Balls { get; set; } 

        //public IReadOnlyList<SingleBallLogic> Balls => _balls.AsReadOnly(); // zwracamy liste tylko do odczytu
        public ITable Table { get; } // tylko do odczytu, hermetyzajca

        //IReadOnlyList<SingleBallLogic> IPhysicsEngine.Balls => _balls.AsReadOnly();

        public PhysicsEngine(int amountBalls)
        {
            _dataAPI = DataAPI.GetDataAPI(amountBalls);

            // dodajemy kule do silnika fizycznego
            ITable table = _dataAPI.GetTable();
            foreach (IBall ball in _dataAPI.GetBalls())
            {
                Balls.Add(new SingleBallLogic(ball, table));
            }
        }

        public PhysicsEngine(IDataAPI dataAPI)
        {
            _dataAPI = dataAPI;

            // dodajemy kule do silnika fizycznego
            ITable table = _dataAPI.GetTable();
            foreach (IBall ball in _dataAPI.GetBalls())
            {
                Balls.Add(new SingleBallLogic(ball, table));
            }
        }

        public void AddBall(IBall ball)
        {
            Balls.Add(new SingleBallLogic(ball, this.Table));
        }

        public void AddBall(SingleBallLogic ball)
        {
            Balls.Add(ball);
        }

        public void RemoveBall(int id)
        {
            // najpierw znajdujemy kule
            SingleBallLogic ball = Balls.Find(b => b.BallData.Id == id);
            if (ball != null)
            {
                Balls.Remove(ball);
            }
        }

        /*public bool IsBallsCollide(int id1, int id2)
        {
            SingleBallLogic ball1 = _balls.Find(b => b.BallData.Id == id1);
            SingleBallLogic ball2 = _balls.Find(b => b.BallData.Id == id2);
            if (ball1 == null || ball2 == null) return false;

            // liczymy odleglosc od srodkow obu kul, wykorzystujemy wzor Pitagorasa
            double distance = Math.Sqrt(Math.Pow(ball1.BallData.X - ball2.BallData.X, 2) + Math.Pow(ball1.BallData.Y - ball2.BallData.Y, 2));

            // sprawdzamy czy odleglosc jest mniejsza od sumy promieni kul
            return distance <= (ball1.BallData.Radius + ball2.BallData.Radius);
        }*/

        public bool IsBallsCollide(SingleBallLogic ball)
        {
            
            if (ball == null) return false;

            foreach (SingleBallLogic b in Balls)
            {
                if (ball.BallData == ball) continue;
                // liczymy odleglosc od srodkow obu kul, wykorzystujemy wzor Pitagorasa
                double distance = Math.Sqrt(Math.Pow(ball.BallData.X - b.BallData.X, 2) + Math.Pow(ball.BallData.Y - b.BallData.Y, 2));

                // sprawdzamy czy odleglosc jest mniejsza od sumy promieni kul
                if (distance <= (ball.BallData.Radius + b.BallData.Radius))
                {
                    return true;
                }
            }

            return false;
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

        public void UpdateBallPosition(SingleBallLogic ball)
        {

            if (ball == null) return;

            // przemyslec czy najpierw dodac predkosc a potem prawdzic czy odwrotnie
            ball.BallData.X += ball.BallData.VelocityX;
            ball.BallData.Y += ball.BallData.VelocityY;

            HandleCollisions(ball);
        }

        public void CheckCollision(object sender, PropertyChangedEventArgs e)
        {
            SingleBallLogic ball = new SingleBallLogic((Ball)sender, Table);

            if (e.PropertyName == nameof(ball.BallData.X) || e.PropertyName == nameof(ball.BallData.Y))
            {
                UpdateBallPosition(ball);
                IsBallCollideHorizontalBand(ball);
            }
        }

        // ruch wszystkich kul
        public void MoveBalls(int newAmountOfBalls)
        {

            _dataAPI.CreateGame(newAmountOfBalls); // tworzymy game dla nowej ilosci kul
            Balls.Clear();
            foreach (IBall ball in _dataAPI.GetBalls())  // idizemy po kazdej kuli
            {
                Balls.Add(new SingleBallLogic(ball, Table)); // dodajemy kule logiki z kuli IBall
                ball.PropertyChanged += CheckCollision; // dodajemy listenera
            }


            //foreach (SingleBallLogic ball in _balls)
            //{
            //    UpdateBallPosition(ball);
            //}
        }

      
    }
}
