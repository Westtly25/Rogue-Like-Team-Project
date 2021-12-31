namespace RogueLike.QuestSystem
{
    public interface IQuestTask
    {
        int ID { get; set; }
        string Title { get; set; }
        int AmountValue { get; }
        int CurrentValue { get; set; }
        Quest QuestMaster { set; }
        TaskStatus QuestTaskStatus { get; set; }
        bool IsCompleted();
    }
}