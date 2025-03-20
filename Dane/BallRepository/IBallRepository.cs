using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Model;

namespace Dane.BallRepository
{
    interface IBallRepository
    {
        Ball GetBallById(int id); 
    }
}
