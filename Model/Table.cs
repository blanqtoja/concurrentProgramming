using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Model
{
    public class Table
    {
        private int id;
        private double width, height;
        private Color color;

        public Table(double width, double height, Color color)
        {
            this.Width = width;
            this.Height = height;
            this.Color = color;
        }

        public int Id { get => id; }
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }
        public Color Color { get => color; set => color = value; }
    }
}
