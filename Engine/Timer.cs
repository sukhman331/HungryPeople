using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Timer
    {
        private float TotalTime { get; set; }
        private float TimeRemaining { get; set; }
        public bool IsRunning { get; set; }

        public event Action OnTimerFinished;

        public void Start(float duration)
        {
            TotalTime = duration;
            TimeRemaining = duration;
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void Update(float deltaTime)
        {
            if (!IsRunning) return;

            TimeRemaining -= deltaTime;

            if (TimeRemaining <= 0)
            {
                IsRunning = false;
                OnTimerFinished?.Invoke();
            }
        }

        public float GetTimeRemaning()
        {
            return TimeRemaining;
        }
    }
}
