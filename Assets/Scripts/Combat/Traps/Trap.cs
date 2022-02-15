using UnityEngine;
using System;
using RogueLike.CharacterSystem;

namespace RogueLike.Combat
{
    [RequireComponent(typeof(BoxCollider))]
    public class Trap : MonoBehaviour
    {
        [SerializeField] private bool isActive = false;
        [SerializeField] private TrapDamagePart trapDamagePart;
        public event Action OnTrapActivated;

        private void Awake()
        {
            trapDamagePart.Initialize(this);
        }

        private void OnEnable()
        {
            trapDamagePart.OnFinished += OnStateChanged;
        }

        private void OnDisable()
        {
            trapDamagePart.OnFinished -= OnStateChanged;
        }

        private void OnTriggerStay(Collider other) 
        {
            if(other.TryGetComponent<CharacterComponent>(out CharacterComponent characterComponent) && !isActive)
            {
                isActive = true;
                OnTrapActivated?.Invoke();
            }
        }

        private void OnStateChanged()
        {
            isActive = (isActive == true) ? false : true;
        }
    }
}