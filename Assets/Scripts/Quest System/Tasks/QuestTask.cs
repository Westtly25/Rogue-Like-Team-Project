using UnityEngine;
using System;

namespace RogueLike.QuestSystem
{
    [Serializable]
    public class QuestTask : IQuestTask
    {
        [SerializeField] protected int id;
        [SerializeField] protected string title;

        [Range(1, 100)]
        [SerializeField] protected int amountValue;
        [SerializeField] protected int currentValue;

        [SerializeField] protected TaskStatus taskStatus = TaskStatus.NotActive;

        [Header("Cache Parent Quest")]
        [SerializeField] protected Quest questMaster;

        [SerializeField] public event Action<TaskStatus> OnTaskStatusChanged;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return $"{currentValue} / {amountValue} {title}"; }
            set { title = value; }
        }

        public bool IsCompleted()
        {
            if(taskStatus == TaskStatus.Completed)
            {
                return true;
            }

            return false;
        }

        public int AmountValue
        {
            get { return amountValue; }
        }

        public int CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                if (currentValue < amountValue)
                {
                    currentValue += value;
                }

                SetCompletQuestTask();
            }
        }

        public Quest QuestMaster
        {
            set
            {
                questMaster = value;
            }
        }

        public TaskStatus QuestTaskStatus
        {
            get
            {
                return taskStatus;
            }
            set
            {
                taskStatus = value;
            }
        }

        protected void SetCompletQuestTask()
        {
            if (currentValue >= amountValue)
            {
                taskStatus = TaskStatus.Completed;

                OnTaskStatusChanged?.Invoke(taskStatus);
            }
            else taskStatus = TaskStatus.Active;
        }
    }
}