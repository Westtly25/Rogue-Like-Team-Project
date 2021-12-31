using UnityEngine;

namespace RogueLike.CharacterEffects
{
    public interface ICharacterEffect
    {
        TimedEffect Initialize(GameObject gameObject);
    }
}