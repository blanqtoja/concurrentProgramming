using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Data.Ball
{
    public interface IBall
    {
        double Radius { get; set; }
        double X { get; set; }
        double Y { get; set; }
        double VelX { get; }
        double VelY { get;}

        void Move(double width, double height);
        void UpdateVelocity(double velocityX, double velocityY);
    }
}
