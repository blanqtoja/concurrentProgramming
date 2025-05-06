using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Model;
using ViewModel.Commands;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ModelAPI modelAPI;
        public ICommand StartCommand { get; set; }
        public ICommand StartSimulationCommand { get; set; }

        public MainViewModel()
        {
            modelAPI = new ModelAPI();
            ballAmount = 0;
            StartCommand = new StartCommand(this);
            StartSimulationCommand = new StartSimulationCommand(this);
        }

        public void Start(object param)
        {
            if (param is WindowSize size)
            {
                var ballLogics = modelAPI.Start(ballAmount, size.Width, size.Height);

                Balls.Clear();

                foreach (var logic in ballLogics)
                {
                    var vm = new BallViewModel(logic);
                    Balls.Add(vm);
                }
                // Timer uruchamiany jest w ModelAPI / SimulationEngine
            }
        }

        private int ballAmount;

        public string BallsAmount
        {
            get => ballAmount.ToString();
            set
            {
                if (int.TryParse(value, out int newValue) && newValue != ballAmount)
                {
                    ballAmount = newValue;
                    OnPropertyChanged(nameof(BallsAmount));
                }
            }
        }

        public ObservableCollection<BallViewModel> Balls { get; } = new ObservableCollection<BallViewModel>();
    }
}
