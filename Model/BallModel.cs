using System.ComponentModel;
using Logic.BallLogic;

public class BallModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public int Id { get; }

    private double radius;
    public double Radius
    {
        get => radius;
        set
        {
            if (radius != value)
            {
                radius = value;
                OnPropertyChanged(nameof(Radius));
            }
        }
    }

    private string color;
    public string Color
    {
        get => color;
        set
        {
            if (color != value)
            {
                color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
    }

    private double x;
    public double X
    {
        get => x;
        set
        {
            if (x != value)
            {
                x = value;
                OnPropertyChanged(nameof(X));
            }
        }
    }

    private double y;
    public double Y
    {
        get => y;
        set
        {
            if (y != value)
            {
                y = value;
                OnPropertyChanged(nameof(Y));
            }
        }
    }

    public double VelocityX { get; set; }
    public double VelocityY { get; set; }

    public BallModel(int id, double radius, string color, double x, double y, double velocityX, double velocityY)
    {
        Id = id;
        Radius = radius;
        Color = color;
        X = x;
        Y = y;
        VelocityX = velocityX;
        VelocityY = velocityY;
    }

    public BallModel(SingleBallLogic ballLogic)
        : this(ballLogic.BallData.Id, ballLogic.BallData.Radius, ballLogic.BallData.Color,
               ballLogic.BallData.X, ballLogic.BallData.Y,
               ballLogic.BallData.VelocityX, ballLogic.BallData.VelocityY)
    {
    }
}
