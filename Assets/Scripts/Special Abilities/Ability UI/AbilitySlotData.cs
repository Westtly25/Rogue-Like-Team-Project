using UnityEngine;

namespace RogueLike.SpecialAbility
{
    [System.Serializable]
    public class AbilitySlotData
    {
        [SerializeField] private ISpecialization specialization;
        [SerializeField] private IAbility ability;

        public ISpecialization Specialization
        {
            get => specialization;
        }

        public IAbility Ability
        {
            get => ability;
        }

        public void SetData(ISpecialization specialization, IAbility ability)
        {
            this.specialization = specialization;
            this.ability = ability;
        }

        public void Clear()
        {
            specialization = null;
            ability = null;
        }
    }
}