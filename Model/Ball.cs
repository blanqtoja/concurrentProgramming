using System;
using System.Drawing;
using System.Xml;

namespace Model
{
    public class Ball
    {
        private int id;
        private double radius;
        private Color color;
        private double x;
        private double y;
        private double velocityX;
        private double velocityY;

        public Ball(int id, double radius, Color color, double x, double y, double velocityX, double velocityY)
        {
            this.id = id;
            this.radius = radius;
            this.color = color;
            this.x = x;
            this.y = y;
            this.velocityX = velocityX;
            this.velocityY = velocityY;

        }


        public double VelocityX { get => velocityX; set => velocityX = value; }
        public double VelocityY { get => velocityY; set => velocityY = value; }
        public double Radius { get => radius; set => radius = value; }
        public Color Color { get => color; set => color = value; }
        public int Id { get => id; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
    }
}
