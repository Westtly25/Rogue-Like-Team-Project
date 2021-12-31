using System;

namespace RogueLike.InventorySystem
{
    public class Apple : IInventoryItem
    {
        private IInventoryItemInfo info;
        private IInventoryItemState state;
        private Type itemType;

        public IInventoryItemInfo Info { get => info; }
        public IInventoryItemState State { get => state; }
        public Type ItemType { get => itemType; }

        public Apple(IInventoryItemInfo info)
        {
            this.info = info;
            state = new InventryItemState();
        }

        public IInventoryItem Clone()
        {
            var clonedApple = new Apple(Info);
            clonedApple.State.Amount = State.Amount;
            return clonedApple;
        }
    }
}