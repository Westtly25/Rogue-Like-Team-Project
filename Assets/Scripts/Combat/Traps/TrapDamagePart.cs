using UnityEngine;
using System.Collections;
using System;

namespace RogueLike.Combat
{
    public class TrapDamagePart : MonoBehaviour
    {
        //TODO Вынести параметры ловушки в отдельный класс
        [SerializeField] private int durationTime = 3;
        public event Action OnFinished;
        private Trap trap;

        public void Initialize(Trap trap)
        {
            this.trap = trap;
        }

        private void OnDisable()
        {
            trap.OnTrapActivated -= OnTrapActivated;
        }

        private void Subscribe()
        {
            trap.OnTrapActivated += OnTrapActivated;
        }

        private void OnTrapActivated()
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            float normalizedTime = 0;

            while(normalizedTime <= durationTime)
            {
                normalizedTime += Time.deltaTime / durationTime;
                yield return null;
            }

            OnFinished?.Invoke();
        }
    }
}