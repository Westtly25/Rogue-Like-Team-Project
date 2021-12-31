using System;

namespace RogueLike.InventorySystem
{
    public interface IInventorySlot
    {
        bool IsFull { get; }
        bool IsEmpty { get; }

        IInventoryItem Item { get; set; }
        Type ItemType { get; }
        int Amount { get; }
        int Capacity { get; set; }

        void SetItem(IInventoryItem Item);
        void Clear();
    }
}
