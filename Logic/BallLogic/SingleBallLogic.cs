using System;
using System.Collections.Generic;
using System.Text;
using Data.Ball;
using Data.Table;

namespace Logic.BallLogic
{
    public class SingleBallLogic
    {
        private IBall _ballData;
        private ITable _tableData;
        public SingleBallLogic(IBall ballData, ITable table)
        {
            BallData = ballData;
            TableData = table;
        }

        public IBall BallData { get => _ballData; set => _ballData = value; }
        public ITable TableData { get => _tableData; set => _tableData = value; }

        public void MoveBall()
        {
            // aktualizujemy pozycje kuli
            BallData.X += BallData.VelocityX;
            BallData.Y += BallData.VelocityY;
            // sprawdzamy czy kula nie wyszla poza stół
            if (BallData.X < 0 || BallData.X > TableData.Width || BallData.Y < 0 || BallData.Y > TableData.Height)
            {
                // zmieniamy kierunek ruchu kuli
                BallData.VelocityX = -BallData.VelocityX;
                BallData.VelocityY = -BallData.VelocityY;
            }
        }
    }
}
