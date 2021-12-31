using UnityEngine;
using System;
using RogueLike.Save;
using System.Collections.Generic;

namespace RogueLike.QuestSystem
{
    [CreateAssetMenu(fileName = "New Quest", menuName = "Rogue Like Prototype / Quest System / Quest's / Create New Quest")]
    public sealed class Quest : ScriptableObject, IQuest, IQuestEvent, ISaveable
    {
        [Header("BACE QUEST DATA")]
        [SerializeField] private int id;
        [SerializeField] private Sprite icon;
        [TextArea()]
        [SerializeField] private string title;
        [TextArea()]
        [SerializeField] private string description;

        [Space]
        [Header("Quest Timer")]
        [SerializeField] private QuestTimeHandler questTimeHandler;
        [Header("Set Quest Status")]
        [SerializeField] private QuestStatus questStatus = QuestStatus.NotActive;
        [Header("Set Quest Reward")]
        [SerializeField] private QuestReward questReward;
        [Header("Set Quest Task Order")]
        [SerializeField] private TaskOrder taskOrder = TaskOrder.Parallel;

        [Header("All QUEST TASKS")]
        [SerializeField] private QuestTask[] questTasks;

        [SerializeField] public event Action<Quest> OnQuestActivated;
        [SerializeField] public event Action<Quest> OnQuestCompleted;
        [SerializeField] public event Action<Quest> OnQuestFailed;
        [SerializeField] public event Action<Quest> OnQuestUpdated;

        [SerializeField] public event Action OnRewardGave;

        private void OnEnable()
        {
            OnSubscribe();
            SetTaskParent();
            SetTaskID();
            ActivateTasks();
        }

        private void OnDisable()
        {
            OnUnSubscribe();
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Sprite Icon
        {
            get => icon;
            set => icon = value;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public QuestTask[] GetTasks()
        {
            return questTasks;
        }

        public QuestReward CurrentQuestReward
        {
            get
            {
                return questReward;
            }
        }

        public QuestStatus CurrentQuestStatus
        {
            get { return questStatus; }
            set { questStatus = value; }
        }

        public void ActivateQuest()
        {
            if (CurrentQuestStatus == QuestStatus.Active) { return; }

            CurrentQuestStatus = QuestStatus.Active;
        }

        public void SetTaskValue(int id, int value)
        {
            for (int i = 0; i < questTasks.Length; i++)
            {
                if (questTasks[i].ID == id)
                {
                    questTasks[i].CurrentValue += value;
                }
            }
        }

        public void OnSubscribe()
        {
            for (int i = 0; i < questTasks.Length; i++)
            {
                questTasks[i].OnTaskStatusChanged += QuestStatusChange;
            }
        }

        public void OnUnSubscribe()
        {
            for (int i = 0; i < questTasks.Length; i++)
            {
                questTasks[i].OnTaskStatusChanged -= QuestStatusChange;
            }
        }

        public void SetTaskParent()
        {
            for (int i = 0; i < questTasks.Length; i++)
            {
                questTasks[i].QuestMaster = this;
            }
        }

        public void SetTaskID()
        {
            for (int i = 0; i < questTasks.Length; i++)
            {
                questTasks[i].ID = i;
            }
        }

        public void QuestStatusChange(TaskStatus taskStatus)
        {
            OnQuestUpdated?.Invoke(this);

            for (int i = 0; i < questTasks.Length; i++)
            {
                if (questTasks[i].QuestTaskStatus == TaskStatus.Active)
                {
                    questStatus = QuestStatus.Active;
                    OnQuestActivated?.Invoke(this);
                    break;
                }
                else if (questTasks[i].QuestTaskStatus == TaskStatus.Failed)
                {
                    questStatus = QuestStatus.Failed;
                    OnQuestFailed?.Invoke(this);
                    break;
                }
            }

            questStatus = QuestStatus.Completed;

            OnQuestCompleted?.Invoke(this);

            OnRewardGave?.Invoke();
        }

        public void GiveReward()
        {
            OnRewardGave.Invoke();
            Debug.Log("Your Reward is Here");
        }

        private void ActivateTasks()
        {
            switch (taskOrder)
            {
                case TaskOrder.Parallel:
                    for (int i = 0; i < questTasks.Length; i++)
                    {
                        questTasks[i].QuestTaskStatus = TaskStatus.Active;
                    }
                    break;
                case TaskOrder.Order:
                    for (int i = 0; i < questTasks.Length; i++)
                    {
                        if(questTasks[i - 1]?.QuestTaskStatus == TaskStatus.Completed &&
                           questTasks[i].QuestTaskStatus == TaskStatus.NotActive)
                        {
                            questTasks[i].QuestTaskStatus = TaskStatus.Active;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }


        [ContextMenu("Save")]
        public async void Save()
        {
            SaveData.Current.Quests.Add(this);

            //SaveSystem.Save();
            await SaveSystem.SaveAsync();
        }

        [ContextMenu("Load")]
        public async void Load()
        {
            await SaveSystem.LoadAsync();
            List<Quest> loaded = SaveData.Current.Quests;
        }
    }
}