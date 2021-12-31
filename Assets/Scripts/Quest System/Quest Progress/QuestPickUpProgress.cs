using UnityEngine;

namespace RogueLike.QuestSystem
{
    public class QuestPickUpProgress : MonoBehaviour
    {
        [SerializeField] private QuestProgressNotifier questProgressNotifier;

        public void PickUp()
        {
            questProgressNotifier.Execute(1);
        }
    }
}