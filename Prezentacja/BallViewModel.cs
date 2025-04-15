using System;
using System.ComponentModel;
using Logic.BallLogic;
using Model;

namespace ViewModel
{
    public class BallViewModel : ViewModelBase
    {
        private readonly IBallLogic _ballLogic;

        public BallViewModel(IBallLogic ballLogic)
        {
            _ballLogic = ballLogic ?? throw new ArgumentNullException(nameof(ballLogic));

            // Inicjalizacja wartości
            X = _ballLogic.BallData.X;
            Y = _ballLogic.BallData.Y;
            Radius = _ballLogic.BallData.Radius;

            // sub zmian z logiki kuli
            _ballLogic.PropertyChanged += OnBallLogicPropertyChanged;
        }

        private double _x;
        public double X
        {
            get => _x;
            private set
            {
                if (_x != value)
                {
                    _x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        private double _y;
        public double Y
        {
            get => _y;
            private set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }

        private double _radius;
        public double Radius
        {
            get => _radius;
            private set
            {
                if (_radius != value)
                {
                    _radius = value;
                    OnPropertyChanged(nameof(Radius));
                }
            }
        }

        private void OnBallLogicPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "BallData")
            {
                X = _ballLogic.BallData.X;
                Y = _ballLogic.BallData.Y;
                Radius = _ballLogic.BallData.Radius;



            }
            
        }

        // anulowanie subskrybcji przy niszczeniu
        ~BallViewModel()
        {
            _ballLogic.PropertyChanged -= OnBallLogicPropertyChanged;
        }
    }
}