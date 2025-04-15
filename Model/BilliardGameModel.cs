using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Logic.BallLogic;
using Logic.PhysicsEngines;

namespace Model
{
    // API
    public class BilliardGameModel
    {
        private IPhysicsEngine _physicsEngine;
        public ObservableCollection<BallModel> BallModels { get; set; }

        // DI API logiki
        //public BilliardGameModel(IPhysicsEngine physicsEngine)
        //{
        //    _physicsEngine = physicsEngine;
        //    BallModels = new ObservableCollection<BallModel>();
        //    foreach (SingleBallLogic b in _physicsEngine.Balls)
        //    {
        //        BallModels.Add(new BallModel(b));
        //    }
        //}
        public BilliardGameModel(int amountBalls)
        {
            _physicsEngine = new PhysicsEngine(amountBalls);
            BallModels = new ObservableCollection<BallModel>();
            foreach (SingleBallLogic b in _physicsEngine.Balls)
            {
                BallModels.Add(new BallModel(b));
            }
            int i = 0;
        }

        // konstruktor z DI API
        public BilliardGameModel(IPhysicsEngine physicsEngine)
        {
            _physicsEngine = physicsEngine;
            BallModels = new ObservableCollection<BallModel>();
            foreach (SingleBallLogic b in _physicsEngine.Balls)
            {
                BallModels.Add(new BallModel(b));
            }
            int i = 0;
        }
        // drugi konstruktor przyjmujacy ilosc kul
        //public BilliardGameModel(int ballAmount)
        //{
        //    _physicsEngine = new PhysicsEngine();
        //    BallModels = new ObservableCollection<BallModel>();
        //    foreach (SingleBallLogic b in _physicsEngine.Balls)
        //    {
        //        BallModels.Add(new BallModel(b));
        //    }
        //}

        public void UpdateGame(int amountBalls)
        {
            _physicsEngine.MoveBalls(amountBalls);
            //BallModels = _physicsEngine.Balls;
            BallModels.Clear();
            foreach ( SingleBallLogic b in _physicsEngine.Balls)
            {
                BallModel model = new BallModel(b);
                BallModels.Add(model);
            }
        }
    }
}
