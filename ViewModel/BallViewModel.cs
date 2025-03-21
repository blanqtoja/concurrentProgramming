using System.ComponentModel;
using Model;

public class BallViewModel : INotifyPropertyChanged
{
    private Ball _ball;
    public double X => _ball.X;
    public double Y => _ball.Y;

    public BallViewModel(Ball ball)
    {
        _ball = ball;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void Update()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
    }
}
