using UnityEngine;
using System;

namespace RogueLike.SpecialAbility
{
    public interface ISpecializationSlot
    {
        ISpecialization GetActiveSpecialization();
        void ChangeSpecialization();
        bool IsEmpty();
        void SetSpecialization(ISpecialization specialization);
        void Clear();

        event Action<ISpecialization> OnSpecializationChangedEvent;
    }
}