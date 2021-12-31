using UnityEngine;

namespace RogueLike.QuestSystem
{
    public interface IQuest
    {
        int ID { get; set; }
        Sprite Icon { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        QuestReward CurrentQuestReward { get; }
        QuestStatus CurrentQuestStatus { get; set; }
        void SetTaskValue(int id, int value);
        QuestTask[] GetTasks();
    }
}