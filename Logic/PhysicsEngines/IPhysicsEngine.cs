using System;
using System.Collections.Generic;
using System.Text;
using Data.Table;
using Data.Ball;
using Logic.BallLogic;

namespace Logic.PhysicsEngines
{
    public interface IPhysicsEngine
    {
        ITable Table { get; } // tylko do oczytu, hermetyzajca
        List<SingleBallLogic> Balls { get; set; } // tylko do oczytu, hermetyzajca

        // Dodanie kuli do silnika fizycznego
        void AddBall(IBall ball);
        // Usuwanie kuli z silnika fizycznego
        void RemoveBall(int id);

        // Czy kula o podanym id kolizjonuje z inną kulą
        //bool IsBallsCollide(int id1, int id2);
        bool IsBallsCollide(SingleBallLogic ball);


        // Czy kula o podanym id kolizjonuje z bandą pozioma
        //bool IsBallCollideHorizontalBand(int id);
        bool IsBallCollideHorizontalBand(SingleBallLogic ball);


        // Czy kula o podanym id kolizjonuje z bandą pozioma
        //bool IsBallCollideVerticalBand(int id);
        bool IsBallCollideVerticalBand(SingleBallLogic ball);


        // Aktualizacja pozycji pojedynczej kuli
        //void UpdateBallPosition(IBall ball);
        void UpdateBallPosition(SingleBallLogic ball);


        // Aktualizacja pozycji wszystkich kul
        void MoveBalls(int newAmountOfBalls);

    }
}
