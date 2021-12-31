using UnityEngine;

namespace RogueLike.QuestSystem
{
    public class QuesKillProgress : MonoBehaviour
    {
        //[SerializeField] private Health health;

        [SerializeField] private QuestProgressNotifier questProgressNotifier;

        public void OnEnable()
        {
            //health = GetComponent<Health>();

            //health.OnQuestActivate += OnKilled;
        }

        public void OnDisable()
        {
            //health.OnQuestActivate -= OnKilled;
        }

        public QuestProgressNotifier GetQuestProgressNotifier()
        {
            return questProgressNotifier;
        }

        public void OnKilled()
        {
            questProgressNotifier.Execute(1);

            //health.OnQuestActivate -= OnKilled;
        }
    }
}