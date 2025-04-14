using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using Logic.Factories.BallFactory;
using Logic.PhysicsEngines;
using Model;
using ViewModel.Stores;

namespace ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        private BilliardGameModel _gameModel; 

        //public GameViewModel(BilliardGameModel gameModel)
        //{
        //    _gameModel = gameModel;
        //}


        private readonly GameStore _gameStore;

        public string BallsCounter => _gameStore.BallsCounter;

        public GameViewModel(GameStore gameStore, BilliardGameModel gameModel)
        {
            _gameModel = gameModel;

            _gameStore = gameStore;
            _gameStore.PropertyChanged += OnGameStoreChanged;
        }

        public GameViewModel()
        {
            _gameModel = new BilliardGameModel();

            _gameStore = new GameStore();
            _gameStore.PropertyChanged += OnGameStoreChanged;
        }

        private void OnGameStoreChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(GameStore.BallsCounter))
                OnPropertyChanged(nameof(BallsCounter));
        }

    }
}
