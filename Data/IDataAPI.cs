using System;
using System.Collections.Generic;
using System.Text;
using Data.Ball;
using Data.Table;

namespace Data
{
    public abstract class IDataAPI
    {
        public static IDataAPI GetDataAPI(int amountBalls)
            { return new DataAPI(amountBalls); }
        public abstract void CreateGame(int amountBalls);
        public abstract List<IBall> GetBalls();
        public abstract ITable GetTable();

    }
}
