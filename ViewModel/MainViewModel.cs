using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Text;
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
                //modelAPI.Start(ballAmount, size.Width, size.Height);
                var ballLogics = modelAPI.Start(ballAmount, size.Width, size.Height);

                Balls.Clear();

                foreach (var logic in ballLogics)
                {
                    var data = logic.BallData;
                    var vm = new BallViewModel(data.X, data.Y, data.Radius);


                    Balls.Add(vm);
                }

                
            }
        }
        public void StartSimulation(object param)
        {
            if (param is WindowSize size)
            {
                while(true)
                { 
                    modelAPI.MoveBalls(size.Width, size.Height); 
                    System.Threading.Thread.Sleep(100); // opóźnienie 100ms
                }


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

        // subskrybujemy zmiany w modelu
        public ObservableCollection<BallViewModel> Balls { get; } = new ObservableCollection<BallViewModel>();

    }
}
