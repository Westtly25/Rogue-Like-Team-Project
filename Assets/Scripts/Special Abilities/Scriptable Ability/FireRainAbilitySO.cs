using UnityEngine;
using System.Collections;
using RogueLike.Combat;

namespace RogueLike.SpecialAbility
{
    [CreateAssetMenu(fileName = "Fire Rain AbilitySO", menuName = "Rogue Like Prototype/Abilities/FireRainAbilitySO", order = 0)]
    public class FireRainAbilitySO : AbilitySO
    {
        [SerializeField] private GameObject rainFireVFX;

        private CharacterController characterController;
        private TargetController targetController;
        private Transform currentTransform;

        public override void Initialize(GameObject parentObject)
        {
            currentTransform = parentObject.transform;
            characterController = parentObject.GetComponent<CharacterController>();
            targetController = parentObject.GetComponent<TargetController>();
        }

        public override IEnumerator Cast()
        {
            if (IsAbilityNotReady()) { yield return null; }

            CurrentAbilityState = AbilityState.Not_Ready;

            GameObject obj = Instantiate(rainFireVFX, currentTransform.position, Quaternion.identity);

            CurrentAbilityState = AbilityState.Casting;

            yield return new WaitForSecondsRealtime(Cooldown);

            CurrentAbilityState = AbilityState.Ready;
        }
    }
}