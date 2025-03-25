using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Model;

namespace Logic
{
    public static class BallFactory
    {
        public static Ball MakeBall(int id, int radius, string color , int x, int y, int velocityX, int velocitY)
        {
            return new Ball( id,  radius, color,  x,  y,  velocityX,  velocitY);
        }

        public static Ball MakeRandomBall(int id, int x, int y)
        {
            Random random = new Random();
            int radius = random.Next(1, 20);
            string color = $"#{random.Next(0, 256):X2}{random.Next(0, 256):X2}{random.Next(0, 256):X2}";
            int velocityX = random.Next(1, 10);
            int velocitY = random.Next(1, 10);
            return MakeBall(id, radius, color, x, y, velocityX, velocitY);
        }
    }
}
