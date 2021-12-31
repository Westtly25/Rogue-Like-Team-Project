using System;

namespace RogueLike.InventorySystem
{
    public class Weapon : IInventoryItem
    {
        private IInventoryItemInfo info;
        private IInventoryItemState state;
        private Type itemType;

        public IInventoryItemInfo Info { get => info; }
        public IInventoryItemState State { get => state; }
        public Type ItemType { get => itemType; }

        public Weapon(IInventoryItemInfo info)
        {
            this.info = info;
            state = new InventryItemState();
        }

        public IInventoryItem Clone()
        {
            var clonedWeapon = new Weapon(Info);
            clonedWeapon.State.Amount = State.Amount;
            return clonedWeapon;
        }
    }
}