using RogueLike.Combat;
using RogueLike.CharactersType;
using RogueLike.Characteristics;
using RogueLike.CharacterSystem;

namespace RogueLike.SpecialAbility
{
    public interface IAbility : IAbilityBase
    {
        public int CurrentLevel { get; set; }
        public int MaxLevel { get; }
        public double Range { get; set; }
        public bool IsOpen { get; set; }
        public bool IsNeedTarget { get; }
        public float Cooldown { get; }
        public DamageType AbilityDamageType { get; }
        public CharacterType CharacterType { get; }
        public ScriptableCharacteristicsContainer CharacteristicsContainer { get; }
        public AbilityOptionSO[] AbilityOptionSOs { get; }
    }
}