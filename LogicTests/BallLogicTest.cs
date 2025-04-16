using System.ComponentModel;
using Data.Ball;
using Logic.BallLogic;

namespace LogicTests
{
    public class BallLogicTest
    {
        private class TestBall : IBall, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private double _x;
            public double X
            {
                get => _x;
                set
                {
                    _x = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
                }
            }

            private double _y;
            public double Y
            {
                get => _y;
                set
                {
                    _y = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
                }
            }

            public double VelocityX { get; set; }
            public double VelocityY { get; set; }
            public double Radius { get; set; }
        }


        [Fact]
        public void MoveBall_ShouldUpdatePosition()
        {
            // Arrange
            var ball = new TestBall
            {
                X = 10,
                Y = 20,
                VelocityX = 5,
                VelocityY = 3,
                Radius = 10
            };

            var ballLogic = new BallLogic(ball);

            // Act
            ballLogic.MoveBall(100, 100);

            // Assert
            Assert.Equal(15, ball.X); // 10 + 5
            Assert.Equal(23, ball.Y); // 20 + 3
        }

        [Fact]
        public void MoveBall_ShouldBounceFromRightWall()
        {
            // Arrange
            var ball = new TestBall
            {
                X = 95,  // Blisko prawej krawêdzi (width = 100)
                Y = 50,
                VelocityX = 10,
                VelocityY = 0,
                Radius = 10
            };

            var ballLogic = new BallLogic(ball);

            // Act
            ballLogic.MoveBall(100, 100);

            // Assert
            // Powinno odbiæ siê od prawej œciany (95 + 10 = 105 > 100 - radius)
            Assert.Equal(-10, ball.VelocityX); // Prêdkoœæ powinna siê odwróciæ
            Assert.True(ball.X < 90); // Nowa pozycja powinna byæ mniejsza ni¿ 90
        }
    }
}