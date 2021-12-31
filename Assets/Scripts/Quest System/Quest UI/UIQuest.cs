using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RogueLike.QuestSystem
{
    public class UIQuest : MonoBehaviour, IUIQuest
    {
        [Header("UI Components")]
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI titleText;

        [Header("Cached Components")]
        [SerializeField] private UIQuestTask taskPrefab;
        [SerializeField] private UITasksList questTaskList;

        private IQuest quest;
        public IQuest Quest
        {
            get => quest;
            set => quest = value;
        }

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            iconImage = iconImage ? GetComponentInChildren<Image>() : iconImage;
            titleText = titleText ? GetComponentInChildren<TextMeshProUGUI>() : titleText;
            questTaskList = questTaskList ?  GetComponentInChildren<UITasksList>() : questTaskList;
        }

        public void SetQuest(IQuest quest)
        {
            Quest = quest;

            iconImage.sprite = quest.Icon;
            titleText.text = quest.Title;

            questTaskList.SetTasks(quest.GetTasks());
        }
    }
}
