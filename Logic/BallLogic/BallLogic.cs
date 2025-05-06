
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
            BallData.X += BallData.VelocityX;
            BallData.Y += BallData.VelocityY;

            //powiadomienie o zmianie pozycji
            OnPropertyChanged(nameof(BallData));

            //sprawdzamy czy kula wyszla poza stół
            if (!IsBallInTable(width, height))
            {
                // zmieniamy kierunek ruchu kuli
                //jesku odbija sie od pionowej sciany to zmieniamy predkosc X
                if (BallData.X - BallData.Radius <= 0 || BallData.X + BallData.Radius >= width)
                {
                    BallData.VelocityX = -BallData.VelocityX;
                }
                //BallData.VelocityX = -BallData.VelocityX;
                //jesli odbija sie od poziomej sciany to zmieniamy predkosc Y
                if (BallData.Y - BallData.Radius <= 0 || BallData.Y + BallData.Radius >= height)
                {
                    BallData.VelocityY = -BallData.VelocityY;
                }
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
            if (!IsBallCollision(otherBall)) return;

            // Pozycje
            double dx = otherBall.X - BallData.X;
            double dy = otherBall.Y - BallData.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance == 0) return; // unika dzielenia przez zero

            // Jednostkowy wektor normalny zderzenia
            double nx = dx / distance;
            double ny = dy / distance;

            // Wektory prędkości
            double v1x = BallData.VelocityX;
            double v1y = BallData.VelocityY;
            double v2x = otherBall.VelocityX;
            double v2y = otherBall.VelocityY;

            // Masa = promień
            double m1 = BallData.Radius;
            double m2 = otherBall.Radius;

            // Różnica prędkości
            double dvx = v1x - v2x;
            double dvy = v1y - v2y;

            // Iloczyn skalarny różnicy prędkości i wektora normalnego
            double dotProduct = dvx * nx + dvy * ny;

            // Jeżeli kule się oddalają, nie przetwarzaj
            if (dotProduct > 0) return;

            // Współczynnik przeniesienia pędu
            double impulse = (2 * dotProduct) / (m1 + m2);

            // Nowe prędkości
            BallData.VelocityX -= impulse * m2 * nx;
            BallData.VelocityY -= impulse * m2 * ny;

            otherBall.VelocityX += impulse * m1 * nx;
            otherBall.VelocityY += impulse * m1 * ny;

            OnPropertyChanged(nameof(BallData));
        }

    }
}
