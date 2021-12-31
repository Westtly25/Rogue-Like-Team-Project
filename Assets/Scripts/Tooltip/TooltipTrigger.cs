using UnityEngine;
using UnityEngine.EventSystems;

namespace RogueLike.Tooltip
{
    public class TooltipTrigger : MonoBehaviour, IPointerExitHandler, IDragHandler, IPointerClickHandler
    {
        public string content;
        public string header;

        public void OnPointerEnter(PointerEventData eventData)
        {
            TooltipSystem.Show(content, header);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            TooltipSystem.Hide();
        }

        public void OnDrag(PointerEventData eventData)
        {
            TooltipSystem.Hide();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            TooltipSystem.Show(content, header);
        }
    }
}