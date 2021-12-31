using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace RogueLike.SpecialAbility
{
    public class AbilityCooldown : MonoBehaviour
    {
        [SerializeField] private Image icon;

        [SerializeField] private float lastTime;

        private IEnumerator enumerator;

        #region Events
        public event Action OnStartCooldownEvent; 
        public event Action OnEndCooldownEvent;
        public event Action<bool> OnCooldownCountEvent;
        #endregion

        private void OnEnable()
        {
            icon = GetComponent<Image>();
        }

        
        public void StartCount(float time)
        {
            enumerator = CooldownEnumerator(time);

            StartCoroutine(enumerator);
        }

        [ContextMenu("Start")]
        public void StartCount()
        {
            enumerator = CooldownEnumerator(25f);

            StartCoroutine(enumerator);
        }

        [ContextMenu("End")]
        public void EndCount()
        {
            StopCoroutine(enumerator);
        }

        private IEnumerator CooldownEnumerator(float time)
        {
            OnStartCooldownEvent?.Invoke();

            float normalizedTime = 1;
            while(normalizedTime >= 0f)
            {
                icon.fillAmount = normalizedTime;
                normalizedTime -= Time.deltaTime / time;

                lastTime = normalizedTime;

                yield return null;
            }

            OnEndCooldownEvent?.Invoke();
        }
    }
}