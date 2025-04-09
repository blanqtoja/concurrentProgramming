using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Model;

namespace ViewModel
{
    public class SingleBallViewModel : ViewModelBase
    {
        private BallModel _ball; // referencja do kuli w modelu

        // bndingi do UI
        public double X => _ball.X;
        public double Y => _ball.Y;
        public double Radius => _ball.Radius;
        public double VelocityX => _ball.VelocityX;
        public double VelocityY => _ball.VelocityY;
        public string Color => _ball.Color;



        public SingleBallViewModel(BallModel ball)
        {
            _ball = ball;
        }
    }
}
