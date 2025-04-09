using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Data.BallRepository
{
    interface IBallRepository
    {
        IBall GetBallById(int id); 
    }
}
