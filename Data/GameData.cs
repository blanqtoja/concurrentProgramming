using System;
using System.Collections.Generic;
using System.Text;
using Data.Ball;
using Data.Table;

namespace Data
{
    public class GameData
    {
        private List<IBall> balls;
        private ITable table;
        public GameData()
        {
            balls = new List<IBall>();
            table = new Table.Table();
        }

        public void addBall(IBall b)
        {
            balls.Add(b);
        }

        public List<IBall> getBalls()
        {
            return balls;
        }

        public ITable getTable()
        {
            return table;
        }
    }
}
