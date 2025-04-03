using System;
using System.Collections.Generic;
using System.Text;
using Data.Table;
using Data.Ball;

namespace Logic.PhysicsEngines
{
    public interface IPhysicsEngine
    {
        ITable Table { get; } // tylko do oczytu, hermetyzajca
        IReadOnlyList<IBall> Balls { get; } // tylko do oczytu, hermetyzajca

        // Dodanie kuli do silnika fizycznego
        void AddBall(IBall ball);
        // Usuwanie kuli z silnika fizycznego
        void RemoveBall(int id);

        // Czy kula o podanym id kolizjonuje z inną kulą
        bool IsBallsCollide(int id1, int id2);

        // Czy kula o podanym id kolizjonuje z bandą pozioma
        bool IsBallCollideHorizontalBand(int id);

        // Czy kula o podanym id kolizjonuje z bandą pozioma
        bool IsBallCollideVerticalBand(int id);

        // Aktualizacja pozycji pojedynczej kuli
        void UpdateBallPosition(IBall ball);

        // Aktualizacja pozycji wszystkich kul
        void MoveBalls();

    }
}
