using System.Linq;
using UnityEngine;

namespace RogueLike.QuestSystem
{
    public class QuestService : MonoBehaviour, IQuestService
    {
        [SerializeField] private QuestDataBase questDataBase;
        public QuestDataBase QuestDataBase
        { 
            get => questDataBase;
            private set => questDataBase = value;
        }

        public IQuest GetQuestByID(int id)
        {
            if(questDataBase.IsEmpty()) { return null; }

            return questDataBase.GetQuestList.FirstOrDefault(i => i.ID == id);
        }

        public IQuest[] GetQuestsByIDs(int[] ids)
        {
            if(questDataBase.IsEmpty()) { return null; }

            Quest[] tempList = null;

            return tempList;
        }

        public IQuest GetRandomQuest()
        {
            if(questDataBase.IsEmpty()) { return null; }

            int randNumber = Random.Range(0, questDataBase.GetQuestList.Length - 1);

            return questDataBase.GetQuestList[randNumber];
        }

        public IQuest[] GetRandomQuestByNumber(int number)
        {
            if(questDataBase.IsEmpty()) { return null; }

            Quest[] tempList = null;

            return tempList;
        }
    }

    public interface IQuestService
    {
        public QuestDataBase QuestDataBase { get; }
        public IQuest GetQuestByID(int id);
        public IQuest[] GetQuestsByIDs(int[] ids);
        public IQuest GetRandomQuest();
        public IQuest[] GetRandomQuestByNumber(int number);
    }
}