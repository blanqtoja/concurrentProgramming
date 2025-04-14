using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Logic.PhysicsEngines;

namespace Logic
{

    // chyba niepotrzebna klasa, bo silnik jest "API"
    public class LogicAPI
    {
        private IPhysicsEngine physicsEngine;
        public LogicAPI(DataAPI dataAPI) 
        {
            dataAPI.CreateGame(1);
            //physicsEngine = new PhysicsEngine(dataAPI.GameData.getTable(), dataAPI.GameData.getBalls());
            //physicsEngine = new PhysicsEngine(dataAPI);
        }
    }
}
