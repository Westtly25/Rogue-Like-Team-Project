using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace RogueLike.SpecialAbility
{
    public class AbilityActionBar : MonoBehaviour
    {
        [SerializeField] private AbilityContainerSO abilityContainer;
        [SerializeField] private SpecializationSO[] specialization;

        [SerializeField] private SpecializationSlot specializationSlot;
        [SerializeField] private List<ActionBarSlot> abilitySlots;

        private void OnEnable()
        {
            Initialize();
            Subscribe();
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        private void Subscribe()
        {
            specializationSlot.OnSpecializationChangedEvent += UpdateAbilitiesSlots;
        }

        private void UnSubscribe()
        {
            specializationSlot.OnSpecializationChangedEvent -= UpdateAbilitiesSlots;
        }

        private void Initialize()
        {
            specializationSlot = GetComponentInChildren<SpecializationSlot>();
            abilitySlots = GetComponentsInChildren<ActionBarSlot>().ToList();

            for (int i = 0; i < specialization.Length; i++)
            {
                specializationSlot.SetSpecialization(specialization[i]);

                AbilitySO[] abilities = abilityContainer.AbilitySOList(specialization[i]);

                for (int slot = 0; slot < abilitySlots.Count; slot++)
                {
                    abilitySlots[slot].SetActionBarItem(specialization[i], abilities[slot]);
                }
            }
        }

        private void UpdateAbilitiesSlots(ISpecialization specialization)
        {
            for (int i = 0; i < abilitySlots.Count; i++)
            {
                abilitySlots[i].ActivateAbility(specialization);
            }
        }

        public void SwapSlotsItems(ActionBarItem fromItem, ActionBarItem toItem)
        {

        }
    }
}