namespace RogueLike.QuestSystem
{
    public interface IQuestEvent
    {
        abstract void OnSubscribe();
        abstract void OnUnSubscribe();
    }
}