namespace RogueLike.QuestSystem
{
    public interface IQuestCell
    {
        string Title { get; set; }
        string Sprite { get; set; }
        float ProgressValue { get; set; }
        QuestStatus QuestStatus { get; set; }

        void SetData(IQuest quest);
    }
}
