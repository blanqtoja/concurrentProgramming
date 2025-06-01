using System;
using System.IO;

namespace Data.Ball
{
    public class Ball : IBall
    {
        private static readonly DiagnosticDataLogger _logger = new DiagnosticDataLogger();
        private static readonly object _logLock = new object();
        private static readonly object _stateLock = new object();
        
        public double Radius { get; set; }
        
        private double _x;
        public double X
        {
            get { lock (_stateLock) { return _x; } }
            set { lock (_stateLock) { _x = value; } }
        }
        
        private double _y;
        public double Y
        {
            get { lock (_stateLock) { return _y; } }
            set { lock (_stateLock) { _y = value; } }
        }
        
        private double VelocityX { get; set; }
        private double VelocityY { get; set; }

        public double VelX => VelocityX;
        public double VelY => VelocityY;

        private static readonly Random Random = new Random();

        public Ball(double radius, double x, double y, double velocityX, double velocityY)
        {
            Radius = radius;
            
            if (x < 0 || y < 0)
            {
                throw new ArgumentOutOfRangeException("Coordinates must be non-negative.");
            }
            X = x;
            Y = y;
            
            VelocityX = velocityX;
            VelocityY = velocityY;
            
            // Logowanie utworzenia nowej piłki
            LogBallState("Created");
        }


        public void Move(double width, double height)
        {
            lock (_stateLock)
            {
                double oldX = X;
                double oldY = Y;
                double oldVelocityX = VelocityX;
                double oldVelocityY = VelocityY;
                
                _x += VelocityX;
                _y += VelocityY;

                bool collisionOccurred = false;
                
                if (_x < 0 || _x + 2 * Radius > width)
                {
                    VelocityX = -VelocityX;
                    collisionOccurred = true;
                }

                if (_y < 0 || _y + 2 * Radius > height)
                {
                    VelocityY = -VelocityY;
                    collisionOccurred = true;
                }
                
                // Logowanie tylko gdy nastąpiła kolizja lub co 10 ruchów
                if (collisionOccurred)
                {
                    LogBallState("Collision");
                }
                else if (Random.Next(10) == 0)
                {
                    LogBallState("Move");
                }
            }
        }
        
        private void LogBallState(string action)
        {
            try
            {
                lock (_logLock)
                {
                    string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ball_movements.csv");
                    bool fileExists = File.Exists(logFilePath);
                    
                    using (StreamWriter writer = new StreamWriter(logFilePath, true))
                    {
                        if (!fileExists)
                        {
                            writer.WriteLine("Timestamp,Action,BallHashCode,X,Y,VelocityX,VelocityY,Radius");
                        }
                        
                        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        writer.WriteLine($"{timestamp},{action},{this.GetHashCode()},{X},{Y},{VelocityX},{VelocityY},{Radius}");
                    }
                }
            }
            catch (Exception ex)
            {
                // W przypadku błędu zapisu, zapisz informację o błędzie do pliku error.log
                string errorFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
                using (StreamWriter errorWriter = new StreamWriter(errorFilePath, true))
                {
                    errorWriter.WriteLine($"{DateTime.Now}: Error logging ball state: {ex.Message}");
                }
            }
        }

        public void UpdateVelocity(double velocityX, double velocityY)
        {
            VelocityX = velocityY;
            VelocityY = velocityY;
        }
    }

   

}
