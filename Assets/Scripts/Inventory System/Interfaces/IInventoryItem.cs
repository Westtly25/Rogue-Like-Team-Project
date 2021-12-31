using System;

namespace RogueLike.InventorySystem
{
    public interface IInventoryItem
    {
        IInventoryItemInfo Info { get; }
        IInventoryItemState State { get; }
        Type ItemType { get; }
        IInventoryItem Clone();
    }
}