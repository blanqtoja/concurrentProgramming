using System;
using System.Collections.Generic;
using Model;

namespace Logic
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

        private void UpdateBallPosition(Ball ball)
        {
            ball.X += ball.VelocityX;
            ball.Y += ball.VelocityY;

            HandleCollisions(ball, table);
        }

        private void HandleCollisions(Ball ball, Table table)
        {
            if(ball == null) return;
            // Implementacja kolizji z bandami

            if (BandXCollision(ball))
            {
                ball.VelocityX = -ball.VelocityX;
            }
            if (BandYCollision(ball))
            {
                ball.VelocityY = -ball.VelocityY;
            }
        }

        // kolizja z banda
        private bool BandXCollision(Ball ball)
        {
            if(ball == null) return false;
            if (ball.X >= table.Width || ball.X <= 0) return true;
            return false;
        }
        private bool BandYCollision(Ball ball)
        {
            if (ball == null) return false;
            if (ball.Y >= table.Width || ball.Y <= 0) return true;
            return false;
        }

        // ruch wszystkich kul
        public void MoveBalls()
        {
            foreach (Ball ball in balls)
            {
                UpdateBallPosition(ball);
            }
        }
    }
}
