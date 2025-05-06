using System;
using System.Collections.Generic;
using System.Timers;
using Logic.BallLogic;

namespace Logic
{
    public class SimulationEngine
    {
        private readonly Timer _timer;
        private readonly List<IBallLogic> _balls;
        private readonly int _width;
        private readonly int _height;

        public SimulationEngine(IEnumerable<IBallLogic> balls, int width, int height)
        {
            _balls = new List<IBallLogic>(balls);
            _width = width;
            _height = height;

            _timer = new Timer(30);
            _timer.Elapsed += OnTick;
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
                        _balls[i].HandleCollision(_balls[j].BallData);
                    }
                }
            }
        }
    }
}
