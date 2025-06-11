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
        double VelocityX { get; set; }
        double VelocityY { get; set; }

        ILogBallEntry CreateLogEntry(string str);
        ILogBallEntry Move(int width, int height);
    }
}
