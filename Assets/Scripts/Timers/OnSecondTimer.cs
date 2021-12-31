namespace RogueLike.Timers
{
    public class OnSecondTimer : Timer
    {
        public OnSecondTimer(float seconds) : base()
        {

        }

        protected override void OnTimerUpdate(float deltaTime)
        {
            if(IsPaused) { return; }

            RemainSecond -= 1f;

            CheckFinished();
        }
    }
}
