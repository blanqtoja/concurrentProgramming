using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Data.Ball;

namespace Logic.BallLogic
{
    public interface IBallLogic: INotifyPropertyChanged
    {
        IBall BallData { get; set; }

        void MoveBall(int width, int height);
        List<ILogBallEntry> HandleCollision(IBall otherBall);
    }
}
