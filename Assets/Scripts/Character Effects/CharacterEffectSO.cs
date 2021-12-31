using UnityEngine;
using RogueLike.Characteristics;

namespace RogueLike.CharacterEffects
{
    public abstract class CharacterEffectSO : ScriptableObject, ICharacterEffect
    {
        [SerializeField] private CharacteristicVariable[] characteristicVariable;

        [SerializeField] protected float timeDuration = 3f;
        [SerializeField] protected bool isStackable = false;
        [SerializeField] protected bool isStackableDuration = false;

        [Range(0, 20)]
        [SerializeField] protected int maxStacks = 1;

        public float TimeDuration => timeDuration;
        public bool IsStackable => isStackable;
        public bool IsStackableDuration => isStackableDuration;
        public int MaxStacks => maxStacks;

        public abstract TimedEffect Initialize(GameObject gameObject);
    }
}