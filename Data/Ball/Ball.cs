using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Xml;

namespace Data.Ball
{
    public class Ball : IBall
    {
        public int Id { get; }
        public double Radius { get; set; }

        // kolor jest przechowywany jako string w formacie hex
        public string Color { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }

        public Ball(int id, double radius, string color, double x, double y, double velocityX, double velocityY)
        {
            Id = id;
            Radius = radius;
            // Sprawdzenie poprawności koloru
            //if (Regex.IsMatch(color, @"^#([0-9A-Fa-f]{3}|[0-9A-Fa-f]{6})$"))
            //{
            //    throw new ArgumentException("Invalid color format. Use hex format (#RRGGBB or #RGB).");
            //}
            Color = color;
            // Sprawdzenie poprawności współrzędnych
            if (x < 0 || y < 0)
            {
                throw new ArgumentOutOfRangeException("Coordinates must be non-negative.");
            }
            X = x;
            Y = y;
            
            VelocityX = velocityX;
            VelocityY = velocityY;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
