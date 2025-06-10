using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Ball
{
    public interface ILogBallEntry
    {
        DateTime Date { get; set; }
        double Ball1Radius { get; set; }
        double Ball1X { get; set; }
        double Ball1Y { get; set; }
        double Ball1VelX { get; set; }
        double Ball1VelY { get; set; }

        //double Ball2Radius { get; set; }
        //double Ball2X { get; set; }
        //double Ball2Y { get; set; }
        //double Ball2VelX { get; set; }
        //double Ball2VelY { get; set; }
    }
}
