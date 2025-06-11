using System;

namespace Data.Ball
{
    public class Ball : IBall
    {
        public double Radius { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }

        private static readonly Random Random = new Random();

        public Ball(double radius, double x, double y, double velocityX, double velocityY)
        {
            Radius = radius;
            
            if (x < 0 || y < 0)
            {
                throw new ArgumentOutOfRangeException("Coordinates must be non-negative.");
            }
            X = x;
            Y = y;
            
            VelocityX = velocityX;
            VelocityY = velocityY;
        }

        public ILogBallEntry CreateLogEntry(string str)
        {
            return new LogBallEntry
            {
                Date = DateTime.Now,
                Ball1Radius = Radius,
                Ball1X = X,
                Ball1Y = Y,
                Ball1VelX = VelocityX,
                Ball1VelY = VelocityY,
                Event = str
            };

        
        }

        public ILogBallEntry Move(int width, int height)
        {
            // aktualizujemy pozycje kuli
            X += VelocityX;
            Y += VelocityY;

            string str = string.Empty;
            ////powiadomienie o zmianie pozycji
            //OnPropertyChanged(nameof(this));


            // Odbicie od lewej/prawej ściany
            if (X - Radius < 0)
            {
                // Console.WriteLine(X);
                X = Radius; 
                VelocityX = -VelocityX;
                str = "Left";
            }
            else if (X + 2 * Radius > width)
            {
                X = width -  2* Radius; 
                VelocityX = -VelocityX;

                str = "Right";

            }

            // Odbicie od górnej/dolnej ściany
            if (Y - Radius < 0)
            {
                Y = Radius;
                VelocityY = -VelocityY;
                str = "Top";

            }
            else if (Y + 2 * Radius > height)
            {
                Y = height - 2 * Radius;
                VelocityY = -VelocityY;
                str = "Bottom";

            }

            if (str != string.Empty)
            {
                return CreateLogEntry(str);
            }
            return null;
        }
    }
}
