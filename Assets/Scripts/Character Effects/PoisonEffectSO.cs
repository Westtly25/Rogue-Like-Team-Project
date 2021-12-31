using UnityEngine;
using RogueLike.Combat;
using RogueLike.Characteristics;

namespace RogueLike.CharacterEffects
{
    [CreateAssetMenu(fileName = "Character EffectSO", menuName = "Rogue Like Prototype/ Character Effects/ Buff/ Poison Character EffectSO", order = 0)]
    public class PoisonEffectSO : CharacterEffectSO
    {
        public override TimedEffect Initialize(GameObject gameObject)
        {
            return new TimedSpeedEffect(this, gameObject);
        }
    }
}