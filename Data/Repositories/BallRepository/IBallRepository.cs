using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Data.Ball;

namespace Data.Repositories
{
    interface IBallRepository
    {
        IBall GetBallById(int id); 
    }
}
