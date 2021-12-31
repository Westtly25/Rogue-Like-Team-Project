using System;

namespace RogueLike.InventorySystem
{
    public class InventorySlot : IInventorySlot
    {
        public bool IsFull => !IsEmpty && Amount == Capacity;

        public bool IsEmpty => Item == null;

        public IInventoryItem Item { get; set; }

        public Type ItemType => Item.ItemType;

        public int Amount => IsEmpty ? 0 : Item.State.Amount;

        public int Capacity { get; set; }

        public void Clear()
        {
            if(IsEmpty) { return; }

            Item.State.Amount = 0;
            Item = null;
        }

        public void SetItem(IInventoryItem item)
        {
            if (!IsEmpty)
            {
                return;
            }

            this.Item = item;
            this.Capacity = Item.Info.MaxItemsInInventory;
        }
    }
}
