using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace View;
public partial class MainWindow : Window
{
    private const int BallCount = 5;
    private const int BallSize = 30;
    private List<Ellipse> balls = new();
    private List<TranslateTransform> ballTransforms = new();
    private List<double> dx = new();
    private List<double> dy = new();

    public MainWindow()
    {
        InitializeComponent();
        InitializeBalls();

        CompositionTarget.Rendering += UpdateBallPositions;
    }

    private void InitializeBalls()
    {
        Random rand = new();

        for (int i = 0; i < BallCount; i++)
        {
            // Tworzymy bilę
            Ellipse ball = new()
            {
                Width = BallSize,
                Height = BallSize,
                Fill = new SolidColorBrush(Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256)))
            };

            // Dodajemy transformację przesunięcia
            TranslateTransform transform = new();
            transform.X = (byte)rand.Next(256);
            transform.Y = (byte)rand.Next(256);
            ball.RenderTransform = transform;

            // Losowe prędkości
            dx.Add(rand.Next(-5, 5));
            dy.Add(rand.Next(-5, 5));

            // Dodajemy do listy
            balls.Add(ball);
            ballTransforms.Add(transform);

            // Dodajemy bilę do Canvas
            GameCanvas.Children.Add(ball);
        }
    }

    private void UpdateBallPositions(object sender, EventArgs e)
    {
        for (int i = 0; i < BallCount; i++)
        {
            ballTransforms[i].X += dx[i];
            ballTransforms[i].Y += dy[i];

            // Odbicie od ścian
            if (ballTransforms[i].X <= 0 || ballTransforms[i].X >= GameCanvas.ActualWidth - BallSize) dx[i] *= -1;
            if (ballTransforms[i].Y <= 0 || ballTransforms[i].Y >= GameCanvas.ActualHeight - BallSize) dy[i] *= -1;
        }
    }
}
