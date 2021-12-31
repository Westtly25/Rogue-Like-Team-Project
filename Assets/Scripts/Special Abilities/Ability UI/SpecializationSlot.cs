using RogueLike.SpecialAbility;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class SpecializationSlot : MonoBehaviour, ISpecializationSlot
{
    [SerializeField] private Image icon;
    [SerializeField] private AbilityCooldown cooldown;
    [SerializeField] private bool isInteractable = true;
    [SerializeField] private float cooldownTime = 0.5f;
    public SpecializationSlotData[] specializationSlotData;

    private Button slotButton;

    public event Action<ISpecialization> OnSpecializationChangedEvent;

    private void Awake()
    {
        slotButton = GetComponent<Button>();
        cooldown = GetComponentInChildren<AbilityCooldown>();
    }

    private void OnEnable()
    {
        slotButton.onClick.AddListener(() => OnPointerClick());

        cooldown.OnStartCooldownEvent += OnCooldownStarted;
        cooldown.OnEndCooldownEvent += OnCooldownFinished;
    }

    private void OnDisable()
    {
        cooldown.OnStartCooldownEvent -= OnCooldownStarted;
        cooldown.OnEndCooldownEvent -= OnCooldownFinished;
    }

    public void Clear()
    {
        icon = null;
    }

    public bool IsEmpty()
    {
        if(specializationSlotData == null)
        {
            return true;
        }

        return false;
    }

    public void SetSpecialization(ISpecialization specialization)
    {
        for (int i = 0; i < specializationSlotData.Length; i++)
        {
            if (specializationSlotData[i].IsEmpty())
            {
                specializationSlotData[i].SetData(specialization);
                icon.sprite = specialization.Icon;
                break;
            }
        }

        specializationSlotData[0].IsActive = true;
    }

    public void OnPointerClick()
    {
        if(isInteractable)
        {
            cooldown.StartCount(cooldownTime);
            ChangeSpecialization();
            OnSpecializationChangedEvent?.Invoke(GetActiveSpecialization());
        }
    }

    public ISpecialization GetActiveSpecialization()
    {
        for (int i = 0; i < specializationSlotData.Length; i++)
        {
            if(specializationSlotData[i].IsActive)
            {
                return specializationSlotData[i].Specialization;
            }
        }

        return null;
    }

    public void ChangeSpecialization()
    {
        if (specializationSlotData[0].IsActive)
        {
            specializationSlotData[0].IsActive = false;
        }
        else
        {
            specializationSlotData[0].IsActive = true;
            icon.sprite = specializationSlotData[0].Specialization.Icon;
        }

        if (specializationSlotData[1].IsActive)
        {
            specializationSlotData[1].IsActive = false;
        }
        else
        {
            specializationSlotData[1].IsActive = true;
            icon.sprite = specializationSlotData[1].Specialization.Icon;
        }
    }

    private void OnCooldownStarted()
    {
        isInteractable = false;
    }

    private void OnCooldownFinished()
    {
        isInteractable = true;
    }
}