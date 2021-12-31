using System;
using UnityEngine;

namespace RogueLike.Characteristics
{
    [Serializable]
    public class CharacteristicVariable : ICharacteristicVariable
    {
        [SerializeField] private ScriptableCharacteristic scriptableCharacteristic;
        [SerializeField] private float[] characteristicValues;
        [SerializeField] private ValueType valueType;

        public ScriptableCharacteristic ScriptableCharacteristic { get => scriptableCharacteristic; }
        public float[] CharacteristicValues { get => characteristicValues; }
    }


    public interface ICharacteristicVariable
    {
        public ScriptableCharacteristic ScriptableCharacteristic { get; }
        public float[] CharacteristicValues { get; }
    }
}

public enum ValueType
{
    Percentage,
    Value
}