namespace RogueLike.Characteristics
{
    public interface ICharacteristicsContainer
    {
        float GetCharacteristicValue(ScriptableCharacteristic characteristic);
        void UpdateCharacteristicValue(ScriptableCharacteristic characteristic, float value);
        void ResetCharacteristicValue(ScriptableCharacteristic characteristic, float value);
        float GetCharacteristicValue(ScriptableCharacteristic characteristic, int level);
        void UpdateCharacteristicValue(ScriptableCharacteristic characteristic, int level, float value);
        void ResetCharacteristicValue(ScriptableCharacteristic characteristic, int level, float value);
        void BuildDictionary();
    }
}