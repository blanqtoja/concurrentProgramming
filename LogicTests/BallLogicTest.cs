using System.ComponentModel;
using Data.Ball;
using Logic.BallLogic;
using System.Collections.Generic;

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

            // Implementacja Move - symuluje ruch kuli z odbiciami
            public void Move(int width, int height)
            {
                // Aktualizuj pozycję
                X += VelocityX;
                Y += VelocityY;

                // Sprawdź odbicia od ścian
                if (X - Radius <= 0)
                {
                    X = Radius;
                    VelocityX = -VelocityX;
                }
                else if (X + Radius >= width)
                {
                    X = width - Radius;
                    VelocityX = -VelocityX;
                }

                if (Y - Radius <= 0)
                {
                    Y = Radius;
                    VelocityY = -VelocityY;
                }
                else if (Y + Radius >= height)
                {
                    Y = height - Radius;
                    VelocityY = -VelocityY;
                }
            }

            public ILogBallEntry CreateLogEntry()
            {
                return new TestLogEntry
                {
                    Ball1Radius = Radius,
                    Ball1X = X,
                    Ball1Y = Y,
                    Ball1VelX = VelocityX,
                    Ball1VelY = VelocityY,
                    Date = DateTime.Now
                };
            }
        }

        private class TestLogEntry : ILogBallEntry
        {
            public DateTime Date { get; set; }
            public double Ball1Radius { get; set; }
            public double Ball1X { get; set; }
            public double Ball1Y { get; set; }
            public double Ball1VelX { get; set; }
            public double Ball1VelY { get; set; }
        }

        [Fact]
        public void BallLogic_Constructor_ShouldInitializeBallData()
        {
            // Arrange
            var ball = new TestBall { X = 10, Y = 20, Radius = 5 };

            // Act
            var ballLogic = new BallLogic(ball);

            // Assert
            Assert.Equal(ball, ballLogic.BallData);
        }

        [Fact]
        public void MoveBall_ShouldCallBallDataMove()
        {
            // Arrange
            var ball = new TestBall
            {
                X = 10,
                Y = 20,
                VelocityX = 5,
                VelocityY = 3,
                Radius = 5
            };

            var ballLogic = new BallLogic(ball);
            var initialX = ball.X;
            var initialY = ball.Y;

            // Act
            ballLogic.MoveBall(100, 100);

            // Assert
            Assert.NotEqual(initialX, ball.X);
            Assert.NotEqual(initialY, ball.Y);
        }

        [Fact]
        public void MoveBall_ShouldTriggerPropertyChanged()
        {
            // Arrange
            var ball = new TestBall
            {
                X = 10,
                Y = 20,
                VelocityX = 5,
                VelocityY = 3,
                Radius = 5
            };

            var ballLogic = new BallLogic(ball);
            var propertyChangedFired = false;
            ballLogic.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == nameof(ballLogic.BallData))
                    propertyChangedFired = true;
            };

            // Act
            ballLogic.MoveBall(100, 100);

            // Assert
            Assert.True(propertyChangedFired);
        }

        [Fact]
        public void MoveBall_WithBoundaryCollision_ShouldBounce()
        {
            // Arrange
            var ball = new TestBall
            {
                X = 95,
                Y = 50,
                VelocityX = 10, // Moving towards right wall
                VelocityY = 0,
                Radius = 5
            };

            var ballLogic = new BallLogic(ball);

            // Act
            ballLogic.MoveBall(100, 100);

            // Assert
            Assert.Equal(-10, ball.VelocityX); // Velocity should reverse
            Assert.Equal(95, ball.X); // Should be corrected to width - radius
        }

        [Fact]
        public void HandleCollision_WithNonCollidingBalls_ShouldReturnNull()
        {
            // Arrange
            var ball1 = new TestBall { X = 10, Y = 10, Radius = 5 };
            var ball2 = new TestBall { X = 50, Y = 50, Radius = 5 };
            var ballLogic = new BallLogic(ball1);

            // Act
            var result = ballLogic.HandleCollision(ball2);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void HandleCollision_WithCollidingBalls_ShouldReturnLogEntries()
        {
            // Arrange
            var ball1 = new TestBall 
            { 
                X = 10, 
                Y = 10, 
                VelocityX = 5, 
                VelocityY = 0, 
                Radius = 5 
            };
            var ball2 = new TestBall 
            { 
                X = 15, 
                Y = 10, 
                VelocityX = -3, 
                VelocityY = 0, 
                Radius = 5 
            };
            var ballLogic = new BallLogic(ball1);

            // Act
            var result = ballLogic.HandleCollision(ball2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count); // Should return 4 log entries
        }

        [Fact]
        public void HandleCollision_WithCollidingBalls_ShouldChangeVelocities()
        {
            // Arrange
            var ball1 = new TestBall 
            { 
                X = 10, 
                Y = 10, 
                VelocityX = 5, 
                VelocityY = 0, 
                Radius = 5 
            };
            var ball2 = new TestBall 
            { 
                X = 15, 
                Y = 10, 
                VelocityX = -3, 
                VelocityY = 0, 
                Radius = 5 
            };
            var ballLogic = new BallLogic(ball1);
            var initialVel1X = ball1.VelocityX;
            var initialVel2X = ball2.VelocityX;

            // Act
            ballLogic.HandleCollision(ball2);

            // Assert
            Assert.NotEqual(initialVel1X, ball1.VelocityX);
            Assert.NotEqual(initialVel2X, ball2.VelocityX);
        }

        [Fact]
        public void BallData_PropertySet_ShouldTriggerPropertyChanged()
        {
            // Arrange
            var ball1 = new TestBall { X = 10, Y = 10, Radius = 5 };
            var ball2 = new TestBall { X = 20, Y = 20, Radius = 5 };
            var ballLogic = new BallLogic(ball1);
            
            var propertyChangedFired = false;
            ballLogic.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == nameof(ballLogic.BallData))
                    propertyChangedFired = true;
            };

            // Act
            ballLogic.BallData = ball2;

            // Assert
            Assert.True(propertyChangedFired);
            Assert.Equal(ball2, ballLogic.BallData);
        }
    }
}