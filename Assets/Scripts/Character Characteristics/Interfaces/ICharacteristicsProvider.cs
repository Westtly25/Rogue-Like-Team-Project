using System;

namespace RogueLike.Characteristics
{
    public interface ICharacteristicsProvider
    {
        void Initialize();
        event Action OnCharacteristicsUpdated;
    }
}