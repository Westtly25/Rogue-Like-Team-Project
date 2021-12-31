using UnityEngine;
using UnityEngine.UI;

namespace RogueLike.SpecialAbility
{
    public class ActionBarSlot : MonoBehaviour, IAbilitySlot
    {
        [Header("Base Params")]
        [SerializeField] private ActionBarItem[] actionBarItems;

        [SerializeField] private Button button;

        private void Awake()
        {
            Initialize();
        }

        private void OnEnable()
        {
            button = GetComponent<Button>();

            button.onClick.AddListener(() => OnClicked());
        }

        public bool IsEmpty()
        {
            if (actionBarItems == null)
            {
                return true;
            }

            return false;
        }

        public void OnClicked()
        {
            if(actionBarItems == null) { return; }

            Debug.Log("Clicked");
        }

        private void Initialize()
        {
            actionBarItems = GetComponentsInChildren<ActionBarItem>();
        }

        public void SetActionBarItem(ISpecialization specialization, IAbility ability)
        {
            for (int i = 0; i < actionBarItems.Length; i++)
            {
                if(actionBarItems[i].IsEmpty())
                {
                    actionBarItems[i].Initialize(specialization, ability);
                    break;
                }
            }
        }

        public void ActivateAbility(ISpecialization specialization)
        {
            Debug.Log($"Set Action Bar Item : {specialization}");

            for (int i = 0; i < actionBarItems.Length; i++)
            {
                if (actionBarItems[i].GetAbilitySlotData.Specialization == specialization)
                {
                    actionBarItems[i].gameObject.SetActive(true);
                    Debug.Log($"Set Active Item : {actionBarItems[i].gameObject.name}");
                }
                else
                {
                    actionBarItems[i].gameObject.SetActive(false);
                    Debug.Log($"Set Not Active Item : {actionBarItems[i].gameObject.name}");
                }
            }
        }
    }
}