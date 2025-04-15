
using System;
using Data.Ball;
using Logic.Factories.BallFactory;

namespace Logic.BallLogic
{
    public class BallLogic : IBallLogic
    {
        public IBall BallData { get; set; }

        public BallLogic(IBall ball)
        {
            BallData = ball;
        }

        public BallLogic(int width, int height)
        {
            BallData = BallFactory.CreateRandomBall(width, height);
        }

        public void MoveBall(int width, int height)
        {
            // aktualizujemy pozycje kuli
            BallData.X += BallData.VelocityX;
            BallData.Y += BallData.VelocityY;

            // sprawdzamy czy kula wyszla poza stół
            if (!IsBallInTable(width, height))
            {
                // zmieniamy kierunek ruchu kuli
                BallData.VelocityX = -BallData.VelocityX;
                BallData.VelocityY = -BallData.VelocityY;
            }
        }

        // tutaj uwzględniamy tylko pozycje kuli, bo rozpatrujemy pojedyncza kule
        private bool IsBallInTable(int width, int height)
        {
            return (BallData.X - BallData.Radius) >= 0 && (BallData.X + BallData.Radius) <= width &&
                    (BallData.Y - BallData.Radius) >= 0 && (BallData.Y + BallData.Radius) <= height;
        }

        // rozpatrujemy zderzenie z inna kula. pierwsza kula to This, druga kula to otherBall
        private bool IsBallCollision(IBall otherBall)
        {
            // sprawdzamy czy odleglosc miedzy kulami jest mniejsza od sumy ich promieni
            double distance = Math.Sqrt(Math.Pow(BallData.X - otherBall.X, 2) + Math.Pow(BallData.Y - otherBall.Y, 2));
            return distance <= (BallData.Radius + otherBall.Radius);
        }

        // sprawdzamy czy kula This zderza sie z inna kula otherBall oraz zmieniamy kierunek ruchu OBU KUL
        public void HandleCollision(IBall otherBall)
        {
            if (IsBallCollision(otherBall))
            {
                // zmieniamy kierunek ruchu obu kul
                BallData.VelocityX = -BallData.VelocityX;
                BallData.VelocityY = -BallData.VelocityY;
                otherBall.VelocityX = -otherBall.VelocityX;
                otherBall.VelocityY = -otherBall.VelocityY;
            }
        }
    }
}
