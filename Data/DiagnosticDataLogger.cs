using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Data.Ball;

namespace Data
{
    public class DiagnosticDataLogger
    {
        private readonly string _filePath;
        private readonly object _lockObject = new object();

        public DiagnosticDataLogger(string filePath = null)
        {
            _filePath = filePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "diagnostic_data.csv");
            
            // Inicjalizacja pliku z nagłówkami
            if (!File.Exists(_filePath))
            {
                lock (_lockObject)
                {
                    using (StreamWriter writer = new StreamWriter(_filePath, false))
                    {
                        writer.WriteLine("Timestamp,BallId,X,Y,VelocityX,VelocityY,Radius");
                    }
                }
            }
        }

        public void LogBallData(IEnumerable<IBall> balls)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                
                int ballId = 0;
                foreach (var ball in balls)
                {
                    sb.AppendLine($"{timestamp},{ballId},{ball.X},{ball.Y},{ball.Radius}");
                    ballId++;
                }

                lock (_lockObject)
                {
                    using (StreamWriter writer = new StreamWriter(_filePath, true))
                    {
                        writer.Write(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // W przypadku błędu zapisu, zapisz informację o błędzie do pliku error.log
                string errorFilePath = Path.Combine(Path.GetDirectoryName(_filePath), "error.log");
                using (StreamWriter errorWriter = new StreamWriter(errorFilePath, true))
                {
                    errorWriter.WriteLine($"{DateTime.Now}: Error logging diagnostic data: {ex.Message}");
                }
            }
        }

        public void LogSimulationStatistics(int ballCount, int width, int height, double averageVelocity)
        {
            try
            {
                string statsFilePath = Path.Combine(Path.GetDirectoryName(_filePath), "simulation_stats.csv");
                bool fileExists = File.Exists(statsFilePath);

                lock (_lockObject)
                {
                    using (StreamWriter writer = new StreamWriter(statsFilePath, true))
                    {
                        if (!fileExists)
                        {
                            writer.WriteLine("Timestamp,BallCount,Width,Height,AverageVelocity");
                        }

                        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        writer.WriteLine($"{timestamp},{ballCount},{width},{height},{averageVelocity}");
                    }
                }
            }
            catch (Exception ex)
            {
                string errorFilePath = Path.Combine(Path.GetDirectoryName(_filePath), "error.log");
                using (StreamWriter errorWriter = new StreamWriter(errorFilePath, true))
                {
                    errorWriter.WriteLine($"{DateTime.Now}: Error logging simulation statistics: {ex.Message}");
                }
            }
        }
    }
}