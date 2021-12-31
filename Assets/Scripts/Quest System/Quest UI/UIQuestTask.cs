using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RogueLike.QuestSystem
{
    public class UIQuestTask : MonoBehaviour, IUIQuestTask
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI valueText;

        private IQuestTask questTask;
        public IQuestTask QuestTask
        { 
            get => questTask;
            set => questTask = value;
        }

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            iconImage = iconImage ? GetComponentInChildren<Image>() : iconImage;
            titleText = titleText ? GetComponentInChildren<TextMeshProUGUI>() : titleText;
            valueText = valueText ? GetComponentInChildren<TextMeshProUGUI>() : valueText;
        }

        public void SetQuestTask(IQuestTask questTask)
        {
            QuestTask = questTask;

            titleText.text = QuestTask.Title;
        }
    }
}