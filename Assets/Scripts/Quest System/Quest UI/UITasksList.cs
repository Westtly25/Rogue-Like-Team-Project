using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.QuestSystem
{
    public class UITasksList : MonoBehaviour
    {
        [SerializeField] private UIQuestTask taskPrefab;

        [SerializeField] private List<UIQuestTask> uIQuestTasks;

        public void SetTasks(IQuestTask[] questTask)
        {
            if (questTask == null) { return; }

            if (taskPrefab == null) { return; }

            for (int i = 0; i < questTask.Length; i++)
            {
                UIQuestTask task = Instantiate(taskPrefab, this.transform.position, Quaternion.identity, this.transform);
                task.SetQuestTask(questTask[i]);
                uIQuestTasks.Add(task);
            }
        }
    }
}