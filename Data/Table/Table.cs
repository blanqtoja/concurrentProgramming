using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace Data.Table
{
    public class Table : ITable
    {
        public int Id { get; }
        public string Color { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MinWidth { get; set; }
        public int MinHeight { get; set; }

        public Table(int id, string color, int width, int height, int minWidth, int minHeight)
        {
            Id = id;

            // Sprawdzenie poprawności koloru
            if(Regex.IsMatch(color, @"^#([0-9A-Fa-f]{3}|[0-9A-Fa-f]{6})$"))
            {
                throw new ArgumentException("Invalid color format. Use hex format (#RRGGBB or #RGB).");
            }
            Color = color;

            // Sprawdzenie poprawności szerokości i wysokości
            if ( width < minWidth && height < minHeight)
            {
                throw new ArgumentOutOfRangeException("Width and height must be greater than minimum values.");
            }
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("Width and height must be higher than 0.");
            }   
            Width = width;
            Height = height;
            MinWidth = minWidth;
            MinHeight = minHeight;
        }

        public Table() 
        {
            Id = 0;
            Color = "#00FF00";
            Width = 800;
            Height = 500;
            MinHeight = 100;
            MinWidth = 100;

        }
    }
}
