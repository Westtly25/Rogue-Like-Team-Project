using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueLike.InventorySystem
{
    public class InventoryWithSlots : IInventory
    {
        public int Capacity { get; set; }

        public bool IsFull => slots.All(slot => slot.IsFull);

        private List<IInventorySlot> slots;

        #region Events
        public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent;
        public event Action<object, Type, int> OnInventoryItemRemovedEvent;
        public event Action<object> OnInventoryStateChangedEvent;
        #endregion

        public InventoryWithSlots(int capacity)
        {
            this.Capacity = capacity;

            slots = new List<IInventorySlot>(capacity);

            for (int i = 0; i < capacity; i++)
            {
                slots.Add(new InventorySlot());
            }
        }

        public IInventoryItem[] GetAllItems()
        {
            List<IInventoryItem> allItems = new List<IInventoryItem>();

            foreach (var slot in slots)
            {
                if(slot.IsEmpty == false)
                {
                    allItems.Add(slot.Item);
                }
            }

            return allItems.ToArray();
        }

        public IInventoryItem[] GetAllItems(Type itemType)
        {
            List<IInventoryItem> allItems = new List<IInventoryItem>();

            List<IInventorySlot> slotsOfType = slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);

            foreach (var slot in slotsOfType)
            {
                allItems.Add(slot.Item);
            }

            return allItems.ToArray();
        }

        public IInventoryItem[] GetEquippedItems()
        {
            List<IInventoryItem> allItems = new List<IInventoryItem>();

            List<IInventorySlot> allItemSlots = slots.FindAll(slot => !slot.IsEmpty && slot.Item.State.IsEquipped);

            foreach (var slot in allItemSlots)
            {
                allItems.Add(slot.Item);
            }

            return allItems.ToArray();
        }

        public IInventoryItem GetItem(Type itemType)
        {
            return slots.Find(slot => slot.ItemType == itemType).Item;
        }

        public int GetItemAmount(Type itemType)
        {
            int amount = 0;

            List<IInventorySlot> allItemSlots = slots.FindAll(slot => slot.IsEmpty && slot.ItemType == itemType);

            foreach (var slot in allItemSlots)
            {
                amount += slot.Amount;
            }

            return amount;
        }

        public bool HasItem(Type type, out IInventoryItem item)
        {
            item = GetItem(type);

            return item != null;
        }

        public void TransitFromSlotToSlot(object sender, IInventorySlot fromSlot, IInventorySlot toSlot)
        {
            if(fromSlot.IsEmpty) { return; }

            if(toSlot.IsFull) { return; }

            if(!toSlot.IsEmpty && fromSlot.ItemType != toSlot.ItemType) { return; }

            var slotCapacity = fromSlot.Capacity;
            var fits = fromSlot.Amount + toSlot.Amount <= slotCapacity;
            var amountToAdd = fits ? fromSlot.Amount : slotCapacity - toSlot.Amount;
            var amountLeft = fromSlot.Amount - amountToAdd;

            if(toSlot.IsEmpty)
            {
                toSlot.SetItem(fromSlot.Item);
                fromSlot.Clear();
                OnInventoryStateChangedEvent?.Invoke(sender);
            }

            toSlot.Item.State.Amount += amountToAdd;
            if(fits)
            {
                fromSlot.Clear();
            }
            else
            {
                fromSlot.Item.State.Amount = amountLeft;
            }

            OnInventoryStateChangedEvent?.Invoke(sender);
        }

        public void RemoveItem(object sender, Type itemType, int amount = 1)
        {
            IInventorySlot[] slotsWithItem = GetAllSlots(itemType);

            if(slotsWithItem.Length == 0)
            {
                return;
            }

            int amountToRemove = amount;
            int count = slotsWithItem.Length;

            for (int i = count - 1; i >= 0; i--)
            {
                var slot = slotsWithItem[i];

                if(slot.Amount >= amountToRemove)
                {
                    slot.Item.State.Amount -= amountToRemove;

                    if (slot.Amount <= 0)
                    {
                        slot.Clear();
                    }

                    OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountToRemove);
                    OnInventoryStateChangedEvent?.Invoke(sender);

                    break;
                }

                int amountRemoved = slot.Amount;
                amountToRemove -= slot.Amount;
                slot.Clear();

                OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountRemoved);
                OnInventoryStateChangedEvent?.Invoke(sender);
            }
        }

        public bool TryToAddItem(object sender, IInventoryItem item)
        {
            IInventorySlot slotsWithSameItemAndNotEmpty = slots.Find(slot => !slot.IsEmpty && slot.ItemType == item.ItemType && !slot.IsFull);

            if(slotsWithSameItemAndNotEmpty != null)
            {
                return TryAddToSlot(sender, slotsWithSameItemAndNotEmpty, item);
            }

            IInventorySlot emptySlot = slots.Find(slot => slot.IsEmpty);

            if(emptySlot != null)
            {
                return TryAddToSlot(sender, emptySlot, item);
            }

            #if UNITY_EDITOR
                Debug.Log($"Cannot add item ({item}), amount: {item.State.Amount}, There is no place for item");
            #endif

            return false;
        }

        public bool TryAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
        {
            bool isFits = slot.Amount + item.State.Amount <= item.Info.MaxItemsInInventory;

            int amountToAdd = isFits ? item.State.Amount : item.Info.MaxItemsInInventory - slot.Amount;

            int amountLeft = item.State.Amount - amountToAdd;

            IInventoryItem cloneItem = item.Clone();

            if (slot.IsEmpty)
            {
                slot.SetItem(cloneItem);
            }
            else slot.Item.State.Amount += amountToAdd;

            OnInventoryItemAddedEvent?.Invoke(sender, item, amountToAdd);
            OnInventoryStateChangedEvent?.Invoke(sender);

            if(amountLeft <= 0)
            {
                return true;
            }

            item.State.Amount = amountLeft;

            return TryToAddItem(sender, item);
        }

        public IInventorySlot[] GetAllSlots(Type itemType)
        {
            return slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType).ToArray();
        }

        public IInventorySlot[] GetAllSlots()
        {
            return slots.ToArray();
        }
    }
}