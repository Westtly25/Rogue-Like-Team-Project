using UnityEngine;

namespace RogueLike.QuestSystem
{
    [System.Serializable]
    public sealed class QuestProgressNotifier
    {
        [SerializeField] private Quest quest;
        [SerializeField] public int taskID;

        public Quest GetQuest()
        {
            return quest;
        }

        public void Execute(int value)
        {
            if (quest.CurrentQuestStatus == QuestStatus.Completed &&
                quest.CurrentQuestStatus == QuestStatus.Failed) { return; }

            quest.SetTaskValue(id : taskID, value: value);
        }
    }
}