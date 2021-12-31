using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using System;

namespace RogueLike.SpecialAbility
{
    public class AbilityOptionSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private Image icon;


        public void SetData(IAbilityOption abilityOption)
        {
            if(abilityOption == null) { return; }

            title.text = String.IsNullOrWhiteSpace(abilityOption.Title) ? abilityOption.Title : "No Data";;
            icon.sprite = abilityOption.Icon;
        }
        
        public void OnPointerClick(PointerEventData pointerEventData)
        {
            Debug.Log(name + "Game Object Click in Progress");
        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            Debug.Log(name + "Game Object Click in Progress");

            this.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        
        public void OnPointerExit(PointerEventData pointerEventData)
        {
            Debug.Log(name + "Game Object Click in Progress");

            this.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        }
    }
}