
using System;
using System.ComponentModel;
using Data.Ball;
using Logic.Factories.BallFactory;

namespace Logic.BallLogic
{
    public class BallLogic : IBallLogic
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IBall _ballData;
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

        public void MoveBall(int width, int height)
        {
            // aktualizujemy pozycje kuli
            double newX = BallData.X + BallData.VelocityX;
            double newY = BallData.Y + BallData.VelocityY;

            //powiadomienie o zmianie pozycji
            //OnPropertyChanged(nameof(BallData));

            //sprawdzamy czy kula wyszla poza stół
            if (!IsBallInTable(width, height))
            {
                // zmieniamy kierunek ruchu kuli
                //jesku odbija sie od pionowej sciany to zmieniamy predkosc X
                if (newX - BallData.Radius <= 0)
                {
                    BallData.X = 0;
                    BallData.Y += VelocityY;
                    BallData.VelocityX = -BallData.VelocityX;

                }
                if (newX + BallData.Radius >= width)
                {
                    

                    BallData.VelocityX = -BallData.VelocityX;
                }
                //BallData.VelocityX = -BallData.VelocityX;
                //jesli odbija sie od poziomej sciany to zmieniamy predkosc Y
                if (newY - BallData.Radius <= 0 || newY + BallData.Radius >= height)
                {
                    BallData.VelocityY = -BallData.VelocityY;
                }

                // przesuniecie kuli tak zeby dotknela sciany
                BallData.X = 
                BallData.Y = 
                //BallData.VelocityY = -BallData.VelocityY;
                OnPropertyChanged(nameof(BallData));

            }

        }

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
        public void HandleCollision(IBall otherBall)
        {
            if (IsBallCollision(otherBall))
            {
                // zmieniamy kierunek ruchu obu kul
                BallData.VelocityX = -BallData.VelocityX;
                BallData.VelocityY = -BallData.VelocityY;
                otherBall.VelocityX = -otherBall.VelocityX;
                otherBall.VelocityY = -otherBall.VelocityY;

                OnPropertyChanged(nameof(BallData));

            }
        }
    }
}
