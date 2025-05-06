using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logic;
using Logic.BallLogic;

namespace Model
{
    public class ModelAPI
    {
        private Collection<IBallLogic> ballsLogic;
        private SimulationEngine _simulationEngine;

        public IEnumerable<IBallLogic> Start(int ballAmount, int width, int height)
        {
            ballsLogic = new Collection<IBallLogic>();

            for (int i = 0; i < ballAmount; i++)
            {
                var ballLogic = new BallLogic(width, height);
                ballsLogic.Add(ballLogic);
            }

            _simulationEngine = new SimulationEngine(ballsLogic, width, height);
            _simulationEngine.Start();

            return ballsLogic;
        }
    }
}
