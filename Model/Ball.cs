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

        public Ball(int id, double radius, Color color, double x, double y)
        {
            this.id = id;
            this.radius = radius;
            this.color = color;
            this.x = x;
            this.y = y;
        }

        /*private class speedVector
        {
            public double x;
            public double y;

            //double radians = (Math.PI / 180) * angleInDegrees;

            public void setX(double radians, double speed)
            {
                x += speed * Math.Cos(radians);
            }

            public void setY(double radians, double speed)
            {
                y += speed * Math.Sin(radians);
            }
        }

        private speedVector speed;*/


        public double Radius { get => radius; set => radius = value; }
        public Color Color { get => color; set => color = value; }
        public int Id { get => id; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
    }
}
