using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using System.Windows.Threading;
using Model;
using ViewModel.Commands;


namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ModelAPI modelAPI;
        public ICommand StartCommand { get; set; }
        public ICommand StartSimulationCommand { get; set; }

        private DispatcherTimer _timer;

        private bool _isSimulationRunning;
        public bool IsSimulationRunning
        {
            get => _isSimulationRunning;
            set
            {
                _isSimulationRunning = value;
            }
        }

        public MainViewModel()
        {
            modelAPI = new ModelAPI();
            ballAmount = 0;
            StartCommand = new StartCommand(this);
            StartSimulationCommand = new StartSimulationCommand(this);


            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(30);
            
        }


        public void Start(object param)
        {
            if (param is WindowSize size)
            {
                //modelAPI.Start(ballAmount, size.Width, size.Height);
                var ballLogics = modelAPI.Start(ballAmount, size.Width, size.Height);

                Balls.Clear();

                foreach (var logic in ballLogics)
                {
                    //var data = logic.BallData;
                    //var vm = new BallViewModel(data.X, data.Y, data.Radius);
                    var vm = new BallViewModel(logic);


                    Balls.Add(vm);
                }

                _timer.Tick += (s, e) => modelAPI.MoveBalls(size.Width, size.Height);
                _timer.Start();

            }
        }

        public void Stop()
        {
            _timer.Stop();
            Balls.Clear();
            modelAPI = new ModelAPI();
            ballAmount = 0;
            OnPropertyChanged(nameof(BallsAmount));
        }

        //public void StartSimulation(object param)
        //{
        //    if (param is WindowSize size)
        //    {
        //        while(true)
        //        { 
        //            modelAPI.MoveBalls(size.Width, size.Height); 
        //            System.Threading.Thread.Sleep(100); // opóźnienie 100ms
        //        }


        //    }

        //}

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

        private WindowSize _currentWindowSize;
        public WindowSize CurrentWindowSize
        {
            get => _currentWindowSize;
            set
            {
                _currentWindowSize = value;
                OnPropertyChanged(nameof(CurrentWindowSize)); // Tutaj podajemy nazwę właściwości
                                                              // Dodatkowa logika reakcji na zmianę rozmiaru
                HandleWindowSizeChanged(value);
            }
        }
        private void HandleWindowSizeChanged(WindowSize newSize)
        {

            // Przykład: możesz zatrzymać i uruchomić symulację od nowa
            if (IsSimulationRunning)
            {
                Stop();
                Start(newSize);
            }
        }

        private WindowSize _windowSize;
        public WindowSize WindowSize
        {
            get => _windowSize;
            set
            {
                _windowSize = value;
                OnPropertyChanged(nameof(WindowSize));
                // Reakcja na zmianę rozmiaru
            }
        }


        // subskrybujemy zmiany w modelu
        public ObservableCollection<BallViewModel> Balls { get; } = new ObservableCollection<BallViewModel>();

    }
}
