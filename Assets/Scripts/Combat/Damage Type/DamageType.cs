using UnityEngine;

namespace RogueLike.Combat
{
    [CreateAssetMenu(fileName = "DamageType", menuName = "Rogue Like Prototype/Damage Types/DamageType", order = 0)]
    public class DamageType : ScriptableObject, IDamageType
    {
        [SerializeField] private string title;
        [SerializeField] private Sprite icon;

        public string Title => title;
        public Sprite Icon => icon;
    }
}