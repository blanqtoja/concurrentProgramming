using System;
using System.Collections.Generic;
using System.ComponentModel;
using Data.Ball;
using Logic.Factories.BallFactory;

namespace Logic.BallLogic
{
    public class BallLogic : IBallLogic
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IBall _ballData;
        private readonly SimulationEngine _engine;
        public IBall BallData
        {
            get => _ballData;
            set
            {
                if (_ballData != value)
                {
                    _ballData = value;
                    OnPropertyChanged(nameof(BallData));
                }
            }
        }
        public BallLogic(IBall ball)
        {
            BallData = ball;
            if (ball is INotifyPropertyChanged notifier)
            {
                notifier.PropertyChanged += (s, e) => OnPropertyChanged(nameof(BallData));
            }
        }

        public BallLogic(int width, int height)
        {
            BallData = BallFactory.CreateRandomBall(width, height);
        }

        public ILogBallEntry MoveBall(int width, int height)
        {
            OnPropertyChanged(nameof(BallData));
            return BallData.Move(width, height);

        }
        //public void MoveBall(int width, int height)
        //{

        //    // aktualizujemy pozycje kuli
        //    BallData.X += BallData.VelocityX;
        //    BallData.Y += BallData.VelocityY;

        //    //powiadomienie o zmianie pozycji
        //    OnPropertyChanged(nameof(BallData));


        //    // Odbicie od lewej/prawej ściany
        //    if (BallData.X - BallData.Radius < 0)
        //    {
        //        // Console.WriteLine(BallData.X);
        //        BallData.X = BallData.Radius; // Korekta pozycji
        //        BallData.VelocityX = -BallData.VelocityX;
                
        //    }
        //    else if (BallData.X + 2 * BallData.Radius > width)
        //    {
        //        BallData.X = width -  2* BallData.Radius; // Korekta pozycji
        //        BallData.VelocityX = -BallData.VelocityX;
                
        //    }

        //    // Odbicie od górnej/dolnej ściany
        //    if (BallData.Y - BallData.Radius < 0)
        //    {
        //        BallData.Y = BallData.Radius; // Korekta pozycji
        //        BallData.VelocityY = -BallData.VelocityY;
                
        //    }
        //    else if (BallData.Y + 2 * BallData.Radius > height)
        //    {
        //        BallData.Y = height - 2 * BallData.Radius; // Korekta pozycji
        //        BallData.VelocityY = -BallData.VelocityY;
        //    }
            
            
        //}

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        //public void HandleCollision(IBall otherBall)

        //zwraca listę czterech ILogBallEntry
        public List<ILogBallEntry> HandleCollision(IBall otherBall)
        {
            if (!IsBallCollision(otherBall)) return null;

            List<ILogBallEntry> logs = new List<ILogBallEntry>();

            // Różnica pozycji i prędkości
            double dx = BallData.X - otherBall.X;
            double dy = BallData.Y - otherBall.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            // Normalizacja wektora różnicy pozycji
            double nx = dx / distance;
            double ny = dy / distance;

            // Różnice prędkości
            double dvx = BallData.VelocityX - otherBall.VelocityX;
            double dvy = BallData.VelocityY - otherBall.VelocityY;

            // Iloczyn skalarny różnicy prędkości i wektora normalnego
            double dot = dvx * nx + dvy * ny;

            // Jeżeli kule się oddalają, nie kolidują fizycznie
            if (dot > 0) return null;

            // Masa = promień (dla uproszczenia)
            double m1 = BallData.Radius;
            double m2 = otherBall.Radius;

            // Współczynnik sprężystości = 1 (sprężyste zderzenie)
            double restitution = 1.0;

            // Oblicz impuls
            double impulse = (2 * dot) / (m1 + m2);


            //ILogBallEntry logDataBallEntryBefore = BallData.CreateLogEntry();
            //ILogBallEntry logOtherBallEntryBefore = BallData.CreateLogEntry();

            // Zaktualizuj prędkości
            BallData.VelocityX -= impulse * m2 * nx;
            BallData.VelocityY -= impulse * m2 * ny;
            otherBall.VelocityX += impulse * m1 * nx;
            otherBall.VelocityY += impulse * m1 * ny;

            OnPropertyChanged(nameof(BallData));

            ILogBallEntry logDataBallEntryAfter = BallData.CreateLogEntry("Collision");
            //ILogBallEntry logOtherBallEntryAfter = BallData.CreateLogEntry("Collision");

            //logs.Add(logDataBallEntryBefore);
            //logs.Add(logOtherBallEntryBefore);
            logs.Add(logDataBallEntryAfter);
            //logs.Add(logDataBallEntryAfter);

            return logs;
        }


    }
}
