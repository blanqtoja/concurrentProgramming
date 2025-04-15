using System;
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
    //obsluga przelaczenstron w oknie
    public class MainViewModel : ViewModelBase
    {
        
        private BilliardGameModel modelAPI;
        private ObservableCollection<BallModel> balls;

        public MainViewModel() {

            modelAPI = new BilliardGameModel(_ballsAmount);
            StartCommand = new StartCommand(this);
            balls = new ObservableCollection<BallModel>();
        }

        public ObservableCollection<BallModel> Balls
        {
            get { return balls; }
            set
            {
                if (balls != value)
                {
                    balls = value;
                    OnPropertyChanged(nameof(Balls));
                }
            }
        }

        private int _ballsAmount;
        public int BallsAmount
        {
            get => _ballsAmount;
            set
            {
                if (_ballsAmount != value)
                {
                    _ballsAmount = value;
                    OnPropertyChanged(nameof(_ballsAmount));
                }
            }
        }

        public ICommand StartCommand { get; }

        public void Update()
        {
            modelAPI.UpdateGame(_ballsAmount);

            Balls.Clear(); // czyści ObservableCollection
            foreach (var ball in modelAPI.BallModels)
            {
                Balls.Add(ball); // dodaje nowe kule
            }

        }
    }
}
