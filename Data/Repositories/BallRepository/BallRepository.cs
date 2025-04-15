using System;
using System.Collections.Generic;
using System.Xml;
using Data.Ball;

namespace Data.Repositories
{
    public class BallRepository: IBallRepository
    {
        private List<IBall> balls;

        public BallRepository(List<IBall> balls)
        {
            Balls = balls;
        }

        public List<IBall> Balls { get => balls; set => balls = value; }

        public IBall GetBallById(int id)
        {
            //for (int i = 0; i < balls.Count; i++)
            //{
            //    if (balls[i].Id == id)
            //    {
            //        return balls[i];
            //    }
            //}

            return null;
        }
    }
}
