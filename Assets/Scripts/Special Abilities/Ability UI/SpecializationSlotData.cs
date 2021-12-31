using RogueLike.SpecialAbility;
using UnityEngine;
using System;

[Serializable]
public class SpecializationSlotData
{
    [SerializeField] private ISpecialization specialization;
    [SerializeField] private bool isActive;

    public ISpecialization Specialization
    {
        get => specialization;
    }

    public bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }

    public void SetData(ISpecialization specialization)
    {
        this.specialization = specialization;
    }

    public void Resetdata()
    {
        isActive = false;
    }

    public bool IsEmpty()
    {
        if(specialization == null)
        {
            return true;
        }

        return false;
    }
}