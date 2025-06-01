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


        public void Move(double width, double height)
        {
            X += VelocityX;
            Y += VelocityY;

            if (X - Radius < 0 || X + Radius > width)
            {
                VelocityX = -VelocityX;
            }

            if (Y - Radius < 0 || Y + Radius > height)
            {
                VelocityY = -VelocityY;
            }        
        }
    }
}
