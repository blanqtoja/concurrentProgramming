using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace Model
{
    public class BillardGame
    {
        private readonly IPhysicsEngine _physicsEngine;

        public BilliardModel(IPhysicsEngine physicsEngine)
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
