using System;
using System.Collections.Generic;
using System.Text;
using Logic.PhysicsEngines;

namespace Model
{
    public class BilliardGameModel
    {
        private readonly IPhysicsEngine _physicsEngine;

        public BilliardGameModel(IPhysicsEngine physicsEngine)
        {
            _physicsEngine = physicsEngine;
        }

        public void UpdateGame()
        {
            _physicsEngine.MoveBalls();
        }
    }
}
