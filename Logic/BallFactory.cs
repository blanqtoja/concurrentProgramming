using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Model;

namespace Logic
{
    public static class BallFactory
    {
        public static Ball MakeBall(int id, int radius, Color color , int x, int y, int velocityX, int velocitY)
        {
            return new Ball( id,  radius, color,  x,  y,  velocityX,  velocitY);
        }

        public static Ball MakeRandomBall(int id, int x, int y)
        {
            Random random = new Random();
            int radius = random.Next(x, 20);
            Color color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            int velocityX = random.Next(1, 10);
            int velocitY = random.Next(1, 10);
            int angle = random.Next(0, 360);
            return MakeBall(id, radius, color, x, y, velocityX, velocitY);
        }
    }
}
