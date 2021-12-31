using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RogueLike.Combat
{
    [RequireComponent(typeof(Collider))]
    public class Trap : MonoBehaviour
    {
        [SerializeField] private bool isActive = false;

        [SerializeField] private TrapDamagePart trapDamagePart;

        private void OnTriggerEnter(Collider other) 
        {
            if(other.tag == "Player" && !isActive)
            {
                isActive = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            isActive = false;
        }
    }
}