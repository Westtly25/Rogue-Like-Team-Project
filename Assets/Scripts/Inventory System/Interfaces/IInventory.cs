using System;

namespace RogueLike.InventorySystem
{
    public interface IInventory
    {
        int Capacity { get; set; }
        bool IsFull { get; }

        IInventoryItem GetItem(Type itemType);
        IInventoryItem[] GetAllItems();
        IInventoryItem[] GetAllItems(Type itemType);
        IInventoryItem[] GetEquippedItems();
        int GetItemAmount(Type itemType);

        bool TryToAddItem(object sender, IInventoryItem item);
        void RemoveItem(object sender, Type itemType, int amount = 1);
        bool HasItem(Type type, out IInventoryItem item);
    }
}
