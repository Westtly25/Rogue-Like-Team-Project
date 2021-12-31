using UnityEngine;

namespace RogueLike.Projectiles
{
    public class ProjectileSO : ScriptableObject
    {
        [SerializeField] private float damage;
        [SerializeField] private float speed;

        public float Damage() => damage;
        public float Speed() => speed;
    }
}