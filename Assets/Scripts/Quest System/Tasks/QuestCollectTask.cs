using UnityEngine;
using RogueLike.InventorySystem;

namespace RogueLike.QuestSystem
{
    [System.Serializable]
    public sealed class QuestCollectTask : QuestTask
    {
        [SerializeField] private InventoryItemInfoSO target;

        public InventoryItemInfoSO Target { get { return target; } }
    }
}