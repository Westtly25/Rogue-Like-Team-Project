using System;
using UnityEngine;

namespace RogueLike.Combat
{
    [Serializable]
    public class ResistanceVariable
    {
        [SerializeField] private DamageType damageType;
        [SerializeField] private bool isInvulnerable;
        
        [Range(0f, 100f)]
        [SerializeField] private float resistancePercentage;

        public DamageType DamageType { get => damageType; }
        public bool IsInvulnerable { get => isInvulnerable; }

        public float ResistancePercentage()
        {
            return isInvulnerable ? 100 : resistancePercentage;
        }
    }
}