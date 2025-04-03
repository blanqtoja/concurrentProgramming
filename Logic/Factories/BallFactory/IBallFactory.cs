using System;
using System.Collections.Generic;
using System.Text;
using Data.Ball;

namespace Logic.Factories.BallFactory
{
    public interface IBallFactory
    {
        IBall MakeBall(int id, int radius, string color, int x, int y, int velocityX, int velocitY);
        IBall MakeRandomBall(int id, int x, int y);
    }
}
