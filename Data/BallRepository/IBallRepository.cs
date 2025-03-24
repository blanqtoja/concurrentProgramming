using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Model;

namespace Data.BallRepository
{
    interface IBallRepository
    {
        Ball GetBallById(int id); 
    }
}
