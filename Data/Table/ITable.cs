using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Table
{
    public interface ITable
    {
        int Id { get; }
        string Color { get; set; }
        int Width { get; set; }
        int Hight { get; set; }
        int MinWidth { get; set; }
        int MinHight { get; set; }

    }
}

