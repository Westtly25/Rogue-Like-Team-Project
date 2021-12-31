using UnityEngine;
using RogueLike.Combat;
using RogueLike.Characteristics;
using RogueLike.CharacterSystem;
using System.Collections;

namespace RogueLike.SpecialAbility
{
    public abstract class AbilitySO : ScriptableObject, IAbility, IAbillityUse
    {
        [Header("BASE ABILITY ATTRIBUTES")]
        [SerializeField] private Sprite icon;
        [SerializeField] private string title;
        
        [SerializeField] [TextArea(0, 4)]
        private string description;

        [Range(0, 100)]
        [SerializeField] private int currentLevel = 0;
        [SerializeField] private const int MAX_LEVEL = 100;
        [SerializeField] private double range;
        [SerializeField] private bool isOpen = false;
        [SerializeField] private bool isNeedTarget = false;
        [SerializeField] private float cooldown = 1f;
        [SerializeField] private AbilityState abilityState;
        [SerializeField] private DamageType abilityDamageType;

        [Header("Target Finder")]
        [SerializeField] private ScriptableTargetFinder targetFinder;

        [Header("CHARACTER")]
        [SerializeField] private CharacterType characterType;

        [Header("CHARACTERISTICS")]
        private ScriptableCharacteristicsContainer characteristicsContainer;

        [Header("Ability Options")]
        [SerializeField] private AbilityOptionSO[] abilityOptionSOs;

        public Sprite Icon => icon;

        public string Title => title;

        public string Description => description;

        public int CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }
        
        public int MaxLevel => MAX_LEVEL;

        public double Range { get; set; }

        public bool IsOpen
        { 
            get { return isOpen; }
            set { isOpen = value; }
        }

        public bool IsNeedTarget => targetFinder;
        public float Cooldown => cooldown;

        public AbilityState CurrentAbilityState
        {
            get { return abilityState; }
            set { abilityState = value; }
        }

        public DamageType AbilityDamageType => abilityDamageType;
        public CharacterType CharacterType => characterType;
        public ScriptableCharacteristicsContainer CharacteristicsContainer => characteristicsContainer;
        public AbilityOptionSO[] AbilityOptionSOs => abilityOptionSOs;

        public abstract void Initialize(GameObject parentObject);

        public abstract IEnumerator Cast();

        protected bool IsAbilityReady()
        {
            if(CurrentAbilityState == AbilityState.Ready)
            {
                return true;
            }

            return false;
        }

        protected bool IsAbilityCasting()
        {
            if(CurrentAbilityState == AbilityState.Casting)
            {
                return true;
            }

            return false;
        }

        protected bool IsAbilityNotReady()
        {
            if(CurrentAbilityState == AbilityState.Not_Ready)
            {
                return true;
            }

            return false;
        }
    }
}