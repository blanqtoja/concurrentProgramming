using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Data.Table;

namespace Logic.Factories.TableFactory
{
    internal class TableFactory : ITableFactory
    {
        public ITable MakeTable(int id, string color, int width, int height, int minWidth, int minHeight)
        {
            // Sprawdzenie poprawności inputu
            if (string.IsNullOrEmpty(color))
            {
                throw new ArgumentException("Color cannot be null or empty.");
            }
            if (Regex.IsMatch(color, @"^#([0-9A-Fa-f]{3}|[0-9A-Fa-f]{6})$"))
            {
                throw new ArgumentException("Invalid color format. Use hex format (#RRGGBB or #RGB).");
            }
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("Width and height must be positive.");
            }
            if (minWidth < 0 || minHeight < 0)
            {
                throw new ArgumentOutOfRangeException("Minimum width and height must be non-negative.");
            }
            if (minWidth > width || minHeight > height)
            {
                throw new ArgumentException("Minimum width and height cannot be greater than actual width and height.");
            }
            
            // Tworzenie obiektu Table
            return new Table(id, color, width, height, minWidth, minHeight);
        }
    }
    
}
