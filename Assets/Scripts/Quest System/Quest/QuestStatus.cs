namespace RogueLike.QuestSystem
{
    [System.Serializable]
    public enum QuestStatus : byte
    {
        Active,
        NotActive,
        Failed,
        Completed
    }
}