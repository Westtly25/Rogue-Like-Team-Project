using UnityEngine;
using System.Collections;

namespace RogueLike.Combat
{
    public class TrapDamagePart : MonoBehaviour
    {
        [SerializeField] private int time = 3;

        private IEnumerator enumerator;

        private void OnEnable()
        {
            enumerator = Countdown();
        }


        private IEnumerator Countdown()
        {
            float duration = 3f; 

            float normalizedTime = 0;
            while(normalizedTime <= 1f)
            {
                normalizedTime += Time.deltaTime / duration;
                yield return null;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(enumerator);
        }

        private void OnTriggerExit(Collider other)
        {
            StopCoroutine(enumerator);
        }
    }
}