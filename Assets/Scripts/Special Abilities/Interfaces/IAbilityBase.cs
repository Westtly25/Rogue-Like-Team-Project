using UnityEngine;

namespace RogueLike.SpecialAbility
{
    public interface IAbilityBase
    {
        public Sprite Icon { get; }
        public string Title { get; }
        public string Description { get; }
    }
}