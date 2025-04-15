using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Data.Ball
{
    public interface IBall : INotifyPropertyChanged
    {
        int Id { get; }
        double Radius { get; set; }
        string Color { get; set; }
        double X { get; set; }
        double Y { get; set; }
        double VelocityX { get; set; }
        double VelocityY { get; set; }


    }
}
