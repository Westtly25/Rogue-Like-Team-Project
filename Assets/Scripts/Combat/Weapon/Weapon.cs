using UnityEngine;

namespace RogueLike.Combat
{
    public class WeaponSystem
    {
        [SerializeField] private IWeapon currentWeapon = null;

        public void SetWeapon(IWeapon weapon)
        {
            currentWeapon = weapon;
        }

        private void CreateWeaponObject()
        {

        }
    }

    public abstract class Weapon : ScriptableObject, IWeapon
    {
        [SerializeField] protected WeaponCharacteristics weaponCharacteristics;
        [SerializeField] protected WeaponVFX weaponVFX;
        [SerializeField] protected DamageType[] damageTypes;
        [SerializeField] private Weapon_Handed_Type weapon_Handed_Type = Weapon_Handed_Type.One_Hand;
        [SerializeField] private GameObject weaponObj;
        [SerializeField] private AnimatorOverrideController weaponAnimator;

        public abstract void MakeDamage();
    }

    public interface IWeapon
    {
        void MakeDamage();
    }

    [System.Serializable]
    public class WeaponCharacteristics
    {
        [SerializeField] private float damage = 1f;
        [SerializeField] private float radius = 2f;
        [SerializeField] private int target = 1;

        public float Damge { get => damage; }
        public float Radius { get => radius; }
        public int Targets { get => target; }
    }

    [System.Serializable]
    public class WeaponVFX
    {
        [SerializeField] private ParticleSystem particleSystem;
        [SerializeField] private AudioClip audioClip;
    }

    [CreateAssetMenu(fileName = "Sword", menuName = "Rogue Like Prototype / Combat / Weapon / Sword Weapon")]
    public class Sword : Weapon
    {
        public override void MakeDamage()
        {
            Debug.Log("Base Sword");
        }
    }

    [CreateAssetMenu(fileName = "Sword", menuName = "Rogue Like Prototype / Combat / Weapon / Sword Weapon")]
    public class Axe : Weapon
    {
        public override void MakeDamage()
        {

        }
    }

    [CreateAssetMenu(fileName = "Sword", menuName = "Rogue Like Prototype / Combat / Weapon / Sword Weapon")]
    public class Bowl : Weapon
    {
        public override void MakeDamage()
        {

        }
    }

    public enum Weapon_Handed_Type
    {
        One_Hand,
        Two_Hand
    }
}