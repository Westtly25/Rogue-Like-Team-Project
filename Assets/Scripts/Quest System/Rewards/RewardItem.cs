using UnityEngine;

namespace RogueLike.QuestSystem
{
    [System.Serializable]
    public sealed class RewardItem
    {
        [Header("Bace Data")]
        [SerializeField] private bool isSelectable;

        public bool IsSelectable => isSelectable;
    }
}