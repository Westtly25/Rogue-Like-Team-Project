using UnityEngine;
using System;

namespace RogueLike.Timers
{
    public abstract class Timer
    {
        public event Action<float> OnTimerValueChangedEvent;
        public event Action OnTimerFinishedEvent;

        private float remainSecond;
        private bool isPaused;


        public float RemainSecond
        { 
            get => remainSecond;
            protected set => remainSecond = value;
        }

        public bool IsPaused
        {
            get => isPaused;
            protected set => isPaused = value;
        }

        public Timer()
        {

        }

        public Timer(float seconds)
        {
            SetTime(seconds);
        }

        public void SetTime(float seconds)
        {
            RemainSecond = seconds;
            OnTimerValueChangedEvent?.Invoke(remainSecond);
        }

        public void Start()
        {
            if(remainSecond == 0)
            {
                OnTimerFinishedEvent?.Invoke();
            }

            isPaused = false;

            OnTimerValueChangedEvent?.Invoke(RemainSecond);
        }

        public void Start(float seconds)
        {
            SetTime(seconds);
            Start();
        }

        public void Pause()
        {
            IsPaused = true;
            OnTimerValueChangedEvent?.Invoke(RemainSecond);
        }

        public void UnPause()
        {
            IsPaused = false;
            OnTimerValueChangedEvent?.Invoke(RemainSecond);
        }

        public void Stop()
        {
            RemainSecond = 0;

            OnTimerValueChangedEvent?.Invoke(RemainSecond);
            OnTimerFinishedEvent?.Invoke();
        }

        protected abstract void OnTimerUpdate(float deltaTime);

        private void OnUpdateTick(float deltaTime)
        {
            if(IsPaused) { return; }

            RemainSecond -= deltaTime;

            CheckFinished();
        }

        protected void CheckFinished()
        {
            if(RemainSecond <= 0)
            {
                Stop();
            }
            else
            {
                OnTimerValueChangedEvent?.Invoke(RemainSecond);
            }
        }
    }
}