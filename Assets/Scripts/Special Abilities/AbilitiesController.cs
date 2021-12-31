using UnityEngine;

namespace RogueLike.SpecialAbility
{
    public class AbilitiesController : MonoBehaviour
    {
        [SerializeField] private AbilityContainerSO abilityContainerSO;

        public void Initialize()
        {
            foreach (var specialization in abilityContainerSO.SpecializationSOsList)
            {
                foreach (AbilitySO ability in specialization.AbilitySOsList)
                {
                    ability.Initialize(this.gameObject);
                }
            }
        }
    }
}