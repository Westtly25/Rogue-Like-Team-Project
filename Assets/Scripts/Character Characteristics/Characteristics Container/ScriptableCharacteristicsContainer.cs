using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Characteristics
{
    [CreateAssetMenu(fileName = "Scriptable Characteristics Container",
                     menuName = "Rogue Like Prototype/Characteristics/Characteristics Containers/Scriptable Characteristics Container",
                     order = 0)]
    public sealed class ScriptableCharacteristicsContainer : ScriptableObject, ICharacteristicsContainer
    {
        [Header("CHARACTER LEVEL")] [Range(1, 100)]
        [SerializeField] private int characterLevel;

        [Header("AVAILABLE CHARACTERISTICS")]
        [SerializeField] private CharacteristicVariable[] characteristicVariable;

        private Dictionary<ScriptableCharacteristic, float[]> сharacteristicVariableDictionary;

        public void Initialization()
        {
            BuildDictionary();
        }

        public void BuildDictionary()
        {
            if(сharacteristicVariableDictionary != null && characteristicVariable == null)
            {
                return;
            }

            сharacteristicVariableDictionary = new Dictionary<ScriptableCharacteristic, float[]>();

            Dictionary<ScriptableCharacteristic, float[]> templDictionary = new Dictionary<ScriptableCharacteristic, float[]>();

            foreach (CharacteristicVariable item in characteristicVariable)
            {
                templDictionary[item.ScriptableCharacteristic] = item.CharacteristicValues;
            }

            сharacteristicVariableDictionary = templDictionary;
        }  

        public void UpdateCharacteristicValue(ScriptableCharacteristic characteristic, float value)
        {
            float[] levels = сharacteristicVariableDictionary[characteristic];

            if (levels.Length < characterLevel)
            {
                return;
            }

            levels[characterLevel - 1] += value;
        }

        public void ResetCharacteristicValue(ScriptableCharacteristic characteristic, float value)
        {
            float[] levels = сharacteristicVariableDictionary[characteristic];

            if (levels.Length < characterLevel)
            {
                return;
            }

            levels[characterLevel - 1] -= value;
        }

        public float GetCharacteristicValue(ScriptableCharacteristic characteristic, int level)
        {
            float[] levels = сharacteristicVariableDictionary[characteristic];

            if (levels.Length < level)
            {
                return 0;
            }

            return levels[level - 1];
        }

        public void UpdateCharacteristicValue(ScriptableCharacteristic characteristic, int level, float value)
        {
            float[] levels = сharacteristicVariableDictionary[characteristic];

            if (levels.Length < level)
            {
                return;
            }

            levels[level - 1] += value;
        }

        public void ResetCharacteristicValue(ScriptableCharacteristic characteristic, int level, float value)
        {
            float[] levels = сharacteristicVariableDictionary[characteristic];

            if (levels.Length < level)
            {
                return;
            }

            levels[level - 1] -= value;
        }     
    }
}