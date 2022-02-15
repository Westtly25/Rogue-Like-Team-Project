using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace RogueLike.Characteristics
{
    public class CharacterisricsProvider : MonoBehaviour, ICharacteristicsProvider
    {
        [Header("CHARACTER CHARACTERISTICS")]
        [SerializeField] private ScriptableCharacteristicsContainer characteristicsContainer;
        public ScriptableCharacteristicsContainer CharacteristicsContainer => characteristicsContainer;

        public event Action OnCharacteristicsUpdated;

        public void Initialize()
        {
            #if UNITY_EDITOR
            if(characteristicsContainer == null)
            {
                Debug.LogWarning($"Character doesn't contains Characteristics Container : {this.gameObject.name} on Characterisrics Controller");
                return;
            }
            #endif

            characteristicsContainer.Initialization();
        }
    }
}