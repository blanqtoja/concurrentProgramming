using ViewModel.Commands;
using ViewModel.Stores;
using ViewModel;

public class IncrementBallsCommand : CommandBase
{
    private readonly GameStore _gameStore;
    private readonly StartViewModel _viewModel;

    public IncrementBallsCommand(GameStore gameStore, StartViewModel viewModel)
    {
        _gameStore = gameStore;
        _viewModel = viewModel;
    }

    // Sprawdza, czy komenda może zostać wykonana
    public override bool CanExecute(object parameter)
    {
        // Komenda może być wykonana, jeśli BallsCounter to liczba
        return int.TryParse(_viewModel.BallsCounter, out _);
    }

    // Wykonuje inkrementację
    public override void Execute(object parameter)
    {
        if (int.TryParse(_viewModel.BallsCounter, out int count))
        {
            _viewModel.BallsCounter = (count + 1).ToString();
        }
    }

    // Opcjonalnie, możesz zaimplementować metodę do informowania o zmianie stanu komendy
    public void NotifyCanExecuteChanged()
    {
        OnCanExecuteChanged();
    }
}
