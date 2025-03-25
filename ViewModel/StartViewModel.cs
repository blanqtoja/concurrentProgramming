using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Input;
using Model;
using ViewModel.Stores;

namespace ViewModel
{
    // w tej klasie znaduje sie strona startowa
    public class StartViewModel : ViewModelBase
    {
        private string _title = "Snooker";
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _counterLabel = "Balls: ";
        public string CounterLabel
        {
            get => _counterLabel;
            set
            {
                _counterLabel = value;
                OnPropertyChanged(nameof(CounterLabel));
            }
        }

        private string _ballsCounter = "0";
        public string BallsCounter
        {
            get => _ballsCounter;
            set 
            {
                _ballsCounter = value;
                OnPropertyChanged(nameof(BallsCounter));
            }
        }

        private string _buttonText = "Start";

        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }

        // obsluga przyciskow
        public ICommand StartCommand { get; }
        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }

        public StartViewModel(NavigationStore navigationStore)
        {
            StartCommand = new Commands.StartCommand(navigationStore);
        }
    }
}
