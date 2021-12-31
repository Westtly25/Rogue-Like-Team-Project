namespace RogueLike.QuestSystem
{
    public interface IQuestTimerHandler
    {
        void OnTimerStarted(QuestTask task);
        void OnTimerUpdated(QuestTask task);
        void OnTimerStopped(QuestTask task);
        void OnReachedTimeLimit(QuestTask task);
    }
}