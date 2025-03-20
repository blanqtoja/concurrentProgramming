using System;
using System.Collections.Generic;
using Model;

namespace Logika
{
    public class PhysicsEngine
    {
        private Table table;
        private List<Ball> balls;

        public PhysicsEngine(Table table, List<Ball> balls)
        {
            this.table = table;
            this.balls = balls;
        }

        // kolizja z banda
        bool BandXCollision(Ball ball)
        {
            if(ball == null) return false;
            if (ball.X >= table.Width || ball.X <= 0) return true;
            return false;
        }
        bool BandYCollision(Ball ball)
        {
            if (ball == null) return false;
            if (ball.Y >= table.Width || ball.Y <= 0) return true;
            return false;
        }

        // poruszanie kula

    }
}
