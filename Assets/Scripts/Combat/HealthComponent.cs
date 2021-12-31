using UnityEngine;
using System;

namespace RogueLike.Combat
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float health;

        public event Action OnHealthEnd;

        public float Health
        { 
            get => health;
            private set => health = value;
        }

        public void TakeDamage(float health)
        {
            Health = Mathf.Min(this.health, health);

            if( Health <= 0 )
            {
                OnHealthEnd?.Invoke();
            }
        }
    }
}