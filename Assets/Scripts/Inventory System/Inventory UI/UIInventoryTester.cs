using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.InventorySystem
{
    public class UIInventoryTester
    {
        private IInventoryItemInfo appleInfo;

        private UIInventorySlot[] uiInventorySlots;

        public InventoryWithSlots InventoryWithSlots { get; set; }

        public UIInventoryTester(IInventoryItemInfo appleInfo, UIInventorySlot[] uiInventorySlots)
        {
            this.appleInfo = appleInfo;
            this.uiInventorySlots = uiInventorySlots;

            InventoryWithSlots = new InventoryWithSlots(15);
            InventoryWithSlots.OnInventoryStateChangedEvent += OnInventoryStateChangedEvent;
        }

        public void FillSlots()
        {
            var slots = InventoryWithSlots.GetAllSlots();
            var availableSlots = new List<IInventorySlot>();

            var filledSlots = 5;

            for (int i = 0; i < filledSlots; i++)
            {
                var filledSlot = AddRandomApples(availableSlots);
                availableSlots.Remove(filledSlot);
            }

            SetupInventoryUI(InventoryWithSlots);
        }

        private void SetupInventoryUI(InventoryWithSlots InventoryWithSlots)
        {
            var allSlots = InventoryWithSlots.GetAllSlots();
            var allSlotsCount = allSlots.Length;

            for (int i = 0; i < allSlotsCount; i++)
            {
                var slot = allSlots[i];
                var uiSlot = uiInventorySlots[i];
                uiSlot.SetSlot(slot);
                uiSlot.Refresh();
            }
        }

        private IInventorySlot AddRandomApples(List<IInventorySlot> slots)
        {
            int randomSlotIndex = UnityEngine.Random.Range(0, slots.Count);
            var rSlot = slots[randomSlotIndex];
            var rCount = UnityEngine.Random.Range(0, 4);
            var apple = new Apple(appleInfo);
            apple.State.Amount = rCount;
            InventoryWithSlots.TryAddToSlot(this, rSlot, apple);
            return rSlot;
        }

        private void OnInventoryStateChangedEvent(object obj)
        {
            foreach (var uiSlot in uiInventorySlots)
            {
                uiSlot.Refresh();
            }
        }
    }
}
