namespace RogueLike.QuestSystem
{
    public interface IUIQuest
    {
        IQuest Quest { get; set; }

        void SetQuest(IQuest quest);
    }
}
