using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Data.Ball;
using Logic.BallLogic;

namespace Logic
{
    public class SimulationEngine
    {
        private readonly System.Timers.Timer _timer;
        private readonly List<IBallLogic> _balls;
        private readonly int _width;
        private readonly int _height;

        public BlockingCollection<ILogBallEntry> logQueue = new BlockingCollection<ILogBallEntry>();
        private ManualResetEvent isLogQueueEmpty = new ManualResetEvent(false);

        public SimulationEngine(IEnumerable<IBallLogic> balls, int width, int height)
        {
            _balls = new List<IBallLogic>(balls);
            _width = width;
            _height = height;

            _timer = new System.Timers.Timer(30);
            _timer.Elapsed += OnTick;

            logger();
        }

        public void Start() => _timer.Start();
        public void Stop() => _timer.Stop();

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            lock (_balls)
            {
                foreach (var ball in _balls)
                {
                    ball.MoveBall(_width, _height);
                }

                for (int i = 0; i < _balls.Count; i++)
                {
                    for (int j = i + 1; j < _balls.Count; j++)
                    {
                        List<ILogBallEntry> logs = _balls[i].HandleCollision(_balls[j].BallData);
                        if(logs == null) continue;
                        foreach (var log in logs)
                        {
                            logQueue.Add(log);
                        }
                    }
                }
            }
        }

        private void logger()
        {
            Task.Run(() => {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss");
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, timestamp + "_collision_log.csv");
                bool fileExists = File.Exists(logFilePath);

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    if (!fileExists)
                    {
                        writer.WriteLine("Date,Radius,X,Y,VelocityX,VelocityY");
                    }

                    foreach (var item in logQueue.GetConsumingEnumerable())
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append($"{item.Date:yyyy-MM-dd HH:mm:ss.fff}");

                        sb.Append($",{item.Ball1Radius.ToString()}");

                        sb.Append($",{item.Ball1X.ToString() ?? ""}");
                        sb.Append($",{item.Ball1Y.ToString()}");

                        sb.Append($",{item.Ball1VelX.ToString() ?? ""}");
                        sb.Append($",{item.Ball1VelY.ToString()}");
                        

                        writer.WriteLine(sb.ToString());
                    }
                    writer.Flush();
                }
                isLogQueueEmpty.Set(); // Signal that the log queue is empty
            });
        }
    }
}
