using System;
using System.Collections.Generic;
using System.Text;
using Data.Ball;

namespace Logic.BallLogic
{
    public interface IBallLogic
    {
        IBall BallData { get; set; }

        void MoveBall(int width, int height);
        void HandleCollision(IBall otherBall);
    }
}
