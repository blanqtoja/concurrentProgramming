using System;
using System.Collections.Generic;
using System.Text;
using Data.Ball;
using Data.Table;

namespace Data
{
    public class DataAPI : IDataAPI
    {
        private GameData gameData;
        
        public DataAPI(int amountBalls)
        {
            CreateGame(amountBalls);
        }
        public GameData GameData { get { return gameData; } }
        public override void CreateGame(int amountBalls)
        {
            gameData = new GameData();
            for (int i = 0; i < amountBalls; i++)
            {
                // trzeba zmienic 
                gameData.addBall(new Ball.Ball(0, 10, "#F00", 100, 100, 10, 10));

            }

            //return gameData;
        }

        public override List<IBall> GetBalls()
        {
            return gameData.getBalls();

        }

        public override ITable GetTable() 
        {
            return GameData.getTable();
        }
    }
}
