using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ViewModel.Stores
{
    public class GameStore : INotifyPropertyChanged
    {
        private string _ballsCounter = "0";

        public string BallsCounter
        {
            get => _ballsCounter;
            set
            {
                if (_ballsCounter != value)
                {
                    _ballsCounter = value;
                    OnPropertyChanged(nameof(BallsCounter));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}


