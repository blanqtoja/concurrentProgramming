using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using Logic;
using Model;

namespace ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        private PhysicsEngine physicsEngine;
        private List<Ball> balls = new List<Ball>();

        private Table table = new Table(300, 400, Color.GreenYellow);
        private Ball ball = BallFactory.MakeBall(0, 10, Color.HotPink, 50,70, 5, 2);
        public GameViewModel()
        {
            balls.Add(ball);
            foreach (Ball ball in balls)
            {
                CreateCircle();
            }
            physicsEngine = new PhysicsEngine(table, balls);
            while(true)
            {
                physicsEngine.MoveBalls();
                
            }
        }

        // tworzy kolko na ekranie
        private void CreateCircle()
        {
         
            
        }


        //public string Title
        //{
        //    get => _title;
        //    set
        //    {
        //        _title = value;
        //        OnPropertyChanged(nameof(Title));
        //    }
        //}
    }
}
