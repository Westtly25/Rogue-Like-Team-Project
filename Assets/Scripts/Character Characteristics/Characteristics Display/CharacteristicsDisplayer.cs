using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Zenject;

namespace RogueLike.Characteristics
{
    public class CharacteristicsDisplayer : MonoBehaviour
    {
        [SerializeField] Image healthBar;
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] ScriptableCharacteristic characteristic;
        
        #region Events SO
        [SerializeField] private event Action<float, float> onHealthUpdated;
        #endregion

        #region Cached Components
        private ICharacteristicsProvider characterisricsProvider;
        #endregion 

        [Inject]
        public void Construct(CharacterisricsProvider characterisricsController)
        {
            this.characterisricsProvider = characterisricsController;
        }

        private void OnEnable()
        {
            Initialize();
            OnSubscribe();
        }

        private void OnDisable()
        {
            OnUnsubscribe();
        }

        private void Initialize()
        {
            if (healthBar == null)
            {
                healthBar = transform.GetChild(1).GetComponentInChildren<Image>();
            }

            if(text == null)
            {
                text = GetComponentInChildren<TextMeshProUGUI>();
            }

            healthBar.fillAmount = 1;
            text.text = "0 / 0";
        }

        private void OnSubscribe()
        {
            if(onHealthUpdated != null)
            {
                //onHealthUpdated.OnEventRised += OnValueUpdated;
            }
        }

        private void OnUnsubscribe()
        {
            if(onHealthUpdated != null)
            {
                //onHealthUpdated.OnEventRised -= OnValueUpdated;
            }
        }

        public void OnValueUpdated(float value, float maxValue)
        {
            healthBar.fillAmount = value / 100;
            text.text = $"{value} / {maxValue}";
        }
    }
}