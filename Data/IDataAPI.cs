using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class IDataAPI
    {
        static IDataAPI GetDataAPI()
            { return new DataAPI(); }
        public abstract void CreateGame(int amountBalls);
    }
}
