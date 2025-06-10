using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Ball
{
    public class LogBallEntry : ILogBallEntry
    {
        public DateTime Date {  get; set; }
        public double Ball1Radius { get; set; }
        public double Ball1X { get; set; }
        public double Ball1Y { get; set; }
        public double Ball1VelX { get; set; }
        public double Ball1VelY { get; set; }

        //public double Ball2Radius { get; set; }
        //public double Ball2X { get; set; }
        //public double Ball2Y { get; set; }
        //public double Ball2VelX { get; set; }
        //public double Ball2VelY { get; set; }




    }
}
