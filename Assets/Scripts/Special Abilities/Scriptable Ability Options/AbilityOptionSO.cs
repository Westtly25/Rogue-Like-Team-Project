using UnityEngine;
using RogueLike.Characteristics;

namespace RogueLike.SpecialAbility
{
    [CreateAssetMenu(fileName = "New Ability OptionSO", menuName = "Rogue Like Prototype/Abilities/Options/Ability OptionSO", order = 0)]
    public class AbilityOptionSO : ScriptableObject, IAbilityOption
    {
        [Header("BASE ABILITY ATTRIBUTES")]
        [SerializeField] private Sprite icon;
        [SerializeField] private string title;
        [SerializeField] private string description;
        [SerializeField] private bool isOpen = false;
        [SerializeField] private CharacteristicVariable[] characteristics;

        public Sprite Icon => icon;

        public string Title => title;

        public string Description => description;
        public bool IsOpen => isOpen;
    }
}