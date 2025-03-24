using System;
using System.Collections.Generic;
using System.Xml;
using Model;

namespace Data.BallRepository
{
    public class BallRepository: IBallRepository
    {
        private List<Ball> balls;

        public BallRepository(List<Ball> balls)
        {
            Balls = balls;
        }

        public List<Ball> Balls { get => balls; set => balls = value; }

        public Ball GetBallById(int id)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].Id == id)
                {
                    return balls[i];
                }
            }

            return null;
        }
    }
}
