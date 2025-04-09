using System;
using System.Collections.Generic;
using System.Text;
using Logic.PhysicsEngines;

namespace Model
{
    // mam watpliwosci co do polaczenia wartsw aplikacji. gdzi epowinny znajdowac sie interfejsy, gdzie implementacja
    public class BilliardGameModel
    {
        private readonly IPhysicsEngine _physicsEngine;

        public BilliardGameModel(IPhysicsEngine physicsEngine)
        {
            _physicsEngine = physicsEngine;
        }

        public IReadOnlyList<IBall> Balls => _physicsEngine.Balls;

        public void UpdateGame()
        {
            _physicsEngine.MoveBalls();
        }
    }
}
