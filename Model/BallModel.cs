using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BallModel
    {
        public BallModel(int id, double radius, string color, double x, double y, double velocityX, double velocityY)
        {
            Id = id;
            Radius = radius;
            Color = color;
            X = x;
            Y = y;
            VelocityX = velocityX;
            VelocityY = velocityY;
        }

        public int Id { get; }
        public double Radius { get; set; }
        public string Color { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }
    }
}
