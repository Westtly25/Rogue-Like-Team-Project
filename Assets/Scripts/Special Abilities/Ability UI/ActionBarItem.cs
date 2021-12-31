using UnityEngine;
using UnityEngine.UI;

namespace RogueLike.SpecialAbility
{
    public class ActionBarItem : MonoBehaviour
    {
        [SerializeField] private AbilitySlotData abilitySlotData;
        [SerializeField] private AbilityCooldown abilityCooldown;
        [SerializeField] private bool isActive = true;

        [SerializeField] private Image icon;

        public AbilitySlotData GetAbilitySlotData => abilitySlotData;

        private void OnEnable()
        {
            icon = GetComponentInChildren<Image>();

            abilityCooldown.OnCooldownCountEvent += CooldownChanged;
        }

        private void OnDisable()
        {
            abilityCooldown.OnCooldownCountEvent -= CooldownChanged;
        }

        public void Initialize(ISpecialization specialization, IAbility ability)
        {
            abilitySlotData.SetData(specialization, ability);
            icon.sprite = ability.Icon;
        }

        public void UpdateData(IAbility ability)
        {
            abilitySlotData.SetData(abilitySlotData.Specialization, ability);
            icon.sprite = ability.Icon;
        }

        public void ClearData()
        {
            abilitySlotData.Clear();
        }

        public bool IsEmpty()
        {
            if (abilitySlotData.Specialization == null && abilitySlotData.Ability == null)
            {
                return true;
            }

            return false;
        }

        public void CooldownChanged(bool isCount)
        {
            isActive = isCount;
        }
    }
}