using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using System.Linq;

namespace RogueLike.SpecialAbility
{
    [CreateAssetMenu(fileName = "New Ability ContainerSO", menuName = "Rogue Like Prototype / Abilities / Containers / Ability ContainerSO", order = 0)]
    public class AbilityContainerSO : ScriptableObject
    {
        [SerializeField] private SpecializationSO[] specializationSOsList;

        public SpecializationSO[] SpecializationSOsList => specializationSOsList;

        public AbilitySO[] AbilitySOList(ISpecialization specialization)
        {
            List<AbilitySO> currentAbilities = new List<AbilitySO>();

            for (int i = 0; i < specializationSOsList.Length; i++)
            {
                if(specializationSOsList[i] == (SpecializationSO)specialization)
                {
                    currentAbilities = specializationSOsList[i].AbilitySOsList.ToList();

                    break;
                }
            }

            return currentAbilities.ToArray();
        }
    }
}