using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;

        public NavigationStore()
        {
            
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel; 
            
            set 
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;
    }
}
