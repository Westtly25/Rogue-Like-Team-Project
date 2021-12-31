using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Characteristics;

namespace RogueLike.SpecialAbility
{
    [CreateAssetMenu(fileName = "New SpecializationSO", menuName = "Rogue Like Prototype/Abilities/Specializations/SpecializationSO", order = 0)]
    public class SpecializationSO : ScriptableObject, ISpecialization
    {
        [Header("BASE ABILITY ATTRIBUTES")]
        [SerializeField] private Sprite icon;
        [SerializeField] private string title;

        [SerializeField] [TextArea(5, 20)]
        private string description;

        [SerializeField] private ScriptableCharacteristicsContainer characteristicsContainer;

        [SerializeField] private AbilitySO[] abilitySOsList;

        public Sprite Icon => icon;

        public string Title => title;

        public string Description => description;

        public AbilitySO[] AbilitySOsList => abilitySOsList;
    }
}