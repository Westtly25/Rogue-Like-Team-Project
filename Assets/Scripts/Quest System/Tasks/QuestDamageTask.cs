using RogueLike.CharacterSystem;
using UnityEngine;

namespace RogueLike.QuestSystem
{
    [System.Serializable]
    public sealed class QuestDamageTask : QuestTask
    {
        [SerializeField] private CharacterType target;

        public CharacterType Target { get { return target; } }
    }
}