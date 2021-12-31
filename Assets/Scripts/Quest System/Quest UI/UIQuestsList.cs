using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RogueLike.QuestSystem
{
    public class UIQuestsList : MonoBehaviour
    {
        [SerializeField] private RectTransform parent;
        [SerializeField] private UIQuest prefab;
        [SerializeField] private List<UIQuest> uIQuests;

        [SerializeField] private IQuestService questService;

        [SerializeField] private IQuest[] quests;

        [Inject]
        public void Construct(IQuestService questService)
        {
            this.questService = questService;
        }

        private void Awake()
        {
            quests = questService.GetRandomQuestByNumber(3);
        }

        private void Start()
        {
            //PopulateList();
        }

        private void PopulateList()
        {
            if(quests == null) { return; }

            for (int i = 0; i < quests.Length; i++)
            {
                UIQuest quest = Instantiate(prefab, parent.transform.position, Quaternion.identity, parent.transform);
                quest.SetQuest(quests[i]);
                uIQuests.Add(quest);
            }
        }
    }
}
