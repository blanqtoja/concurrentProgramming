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
        private readonly IPhysicsEngine _physicsEngine;
        private ObservableCollection<BallModel> BallModels {  get; }

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
        public BilliardGameModel()
        {
            //_physicsEngine = physicsEngine;
            //BallModels = new ObservableCollection<BallModel>();
            //foreach (SingleBallLogic b in _physicsEngine.Balls)
            //{
            //    BallModels.Add(new BallModel(b));
            //}
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

        public void UpdateGame()
        {
            _physicsEngine.MoveBalls();
        }
    }
}
