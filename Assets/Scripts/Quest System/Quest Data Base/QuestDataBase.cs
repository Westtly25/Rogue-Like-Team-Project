using UnityEngine;

namespace RogueLike.QuestSystem
{
    [CreateAssetMenu(fileName = "New Quest Data Base", menuName = "Rogue Like Prototype / Quest System / Data Base /Create New Quest Data Base")]
    public class QuestDataBase : ScriptableObject
    {
        [SerializeField] private Quest[] questConfigsList;
        
        private void SetQuestsID()
        {
            if (questConfigsList == null) { return; }

            for (int i = 0; i < questConfigsList.Length; i++)
            {
                questConfigsList[i].ID = i;
            }
        }

        public Quest[] GetQuestList => questConfigsList;

        public bool IsEmpty()
        {
            if(questConfigsList.Length <= 0)
            {
                Debug.LogError("There aren't any quest in data base, please check data base and set quest's");
                return true;
            }

            Debug.Log($"All Quest's are set, current quest's count in data base is : {questConfigsList.Length}");
            return false;
        }
    }
}