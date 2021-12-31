using UnityEngine;

namespace RogueLike.InventorySystem
{
    public class UIInventory : MonoBehaviour
    {
        private IInventoryItemInfo appleInfo;
        private InventoryWithSlots inventory;
        public InventoryWithSlots Inventory { get => iInventoryTester.InventoryWithSlots; private set => inventory = value; }

        private UIInventoryTester iInventoryTester;

        private void Start()
        { 
            var uiSlots = GetComponentsInChildren<UIInventorySlot>();
            iInventoryTester = new UIInventoryTester(appleInfo, uiSlots);
            iInventoryTester.FillSlots();
        }
    }
}
