using System;
using UnityEngine;

namespace RogueLike.InventorySystem
{
    [Serializable]
    public class InventryItemState : IInventoryItemState
    {
        [SerializeField] private int amount;
        [SerializeField] private bool isEquipped;

        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public bool IsEquipped
        {
            get => IsEquipped;
            set => IsEquipped = value;
        }

        public InventryItemState()
        {
            amount = 0;
            IsEquipped = false;
        }
    }
}
