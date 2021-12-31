using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Combat
{
    [RequireComponent(typeof(HealthComponent))]
    public class Damageble : MonoBehaviour, IDamageable
    {
        [SerializeField] private HealthComponent health;

        private void Awake() => Initialize();

        private void Initialize()
        {
            if ( health == null )
            {
                health = GetComponent<HealthComponent>();
            }
        }

        public void MakeDamage()
        {
            health.TakeDamage(health.Health);
        }

        public void MakeDamage(float damage)
        {
            health.TakeDamage(damage);
        }
    }
}