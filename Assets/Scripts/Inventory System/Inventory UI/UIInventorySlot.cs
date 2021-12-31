using UnityEngine;
using UnityEngine.EventSystems;

namespace RogueLike.InventorySystem
{
    public class UIInventorySlot : UISlot
    {
        [SerializeField] private IInventorySlot slot;
        [SerializeField] private UIInventory uiInventory;
        [SerializeField] private UIInventoryItem uiInventoryItem;

        private void Awake()
        {
            uiInventory = GetComponentInParent<UIInventory>();
        }

        public IInventorySlot Slot => slot;

        public void SetSlot(IInventorySlot inventorySlot)
        {
            slot = inventorySlot;
        }

        public override void OnDrop(PointerEventData eventData)
        {
            var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
            var otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();
            var otherSlot = otherSlotUI.slot;
            var inventory = uiInventory.Inventory;

            inventory.TransitFromSlotToSlot(this, otherSlot, slot);

            Refresh();
            otherSlotUI.Refresh();
        }

        public void Refresh()
        {
            if(slot != null)
            {
                uiInventoryItem.Refresh(slot);
            }
        }
    }
}