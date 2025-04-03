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
        public int Hight { get; set; }
        public int MinWidth { get; set; }
        public int MinHight { get; set; }

        public Table(int id, string color, int width, int hight, int minWidth, int minHight)
        {
            Id = id;

            // Sprawdzenie poprawności koloru
            if(Regex.IsMatch(color, @"^#([0-9A-Fa-f]{3}|[0-9A-Fa-f]{6})$"))
            {
                throw new ArgumentException("Invalid color format. Use hex format (#RRGGBB or #RGB).");
            }
            Color = color;

            // Sprawdzenie poprawności szerokości i wysokości
            if ( width < minWidth && hight < minHight)
            {
                throw new ArgumentOutOfRangeException("Width and height must be greater than minimum values.");
            }
            if (width <= 0 || hight <= 0)
            {
                throw new ArgumentOutOfRangeException("Width and height must be higher than 0.");
            }   
            Width = width;
            Hight = hight;
            MinWidth = minWidth;
            MinHight = minHight;
        }
    }
}
