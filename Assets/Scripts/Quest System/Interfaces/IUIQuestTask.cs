namespace RogueLike.QuestSystem
{
    public interface IUIQuestTask
    {
        IQuestTask QuestTask { get; set; }

        void SetQuestTask(IQuestTask questTask);
    }
}
