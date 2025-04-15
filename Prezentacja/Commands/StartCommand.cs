using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Commands
{
    public class StartCommand : CommandBase
    {
        private MainViewModel _srcViewModel;
        public StartCommand(MainViewModel srcViewModel)
        {
            _srcViewModel = srcViewModel;
        }
        public override void Execute(object parameter)
        {
            _srcViewModel.Start(parameter);
        }
    }

}
