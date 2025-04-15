using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Data.Ball;

namespace Logic.Factories.BallFactory
{
    public static class BallFactory
    {
        public static IBall CreateBall(int radius, int x, int y, int velocityX, int velocitY)
        {
            return new Ball(radius, x, y, velocityX, velocitY);
        }

        public static IBall CreateRandomBall(int maxX, int maxY)
        {
            Random random = new Random();
            int radius = random.Next(1, 20);
            int x = random.Next(radius, maxX-radius);
            int y = random.Next(radius, maxY-radius);
            int velocityX = random.Next(1, 10);
            int velocitY = random.Next(1, 10);
            return CreateBall(radius, x, y, velocityX, velocitY);
        }
    }
}
