namespace RogueLike.Characteristics
{
    public interface ICharacteristicsContainer
    {
        void Initialization();
        void UpdateCharacteristicValue(ScriptableCharacteristic characteristic, float value);
        void ResetCharacteristicValue(ScriptableCharacteristic characteristic, float value);
        float GetCharacteristicValue(ScriptableCharacteristic characteristic, int level);
        void UpdateCharacteristicValue(ScriptableCharacteristic characteristic, int level, float value);
        void ResetCharacteristicValue(ScriptableCharacteristic characteristic, int level, float value);
    }
}