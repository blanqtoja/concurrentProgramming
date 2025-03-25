using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using Logic;
using Model;

namespace ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        // silnik fizyczny gry
        private PhysicsEngine _physicsEngine;

        // ista przechowujaca wszystkie kule
        private List<Ball> _balls = new List<Ball>();

        // stol
        private Table _table;
        // kula
        private Ball _ball;

        // obserwowalna lista kulek
        public ObservableCollection<SingleBallViewModel> Circles { get; } = new ObservableCollection<SingleBallViewModel>();

        public GameViewModel()
        {

            _table = new Table(300, 400, Color.GreenYellow);
            _ball = BallFactory.MakeBall(0, 20, "#ffaaaa", 200, 150, 5, 2);

            _balls.Add(_ball);

            _physicsEngine = new PhysicsEngine(_table, _balls);

            // dodanie kulek do listy obserwowalnej
            foreach (var ball in _balls)
            {
                Circles.Add(new SingleBallViewModel(ball));
            }

        }

    }
}
