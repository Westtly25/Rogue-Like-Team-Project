using UnityEngine;

namespace RogueLike.InventorySystem
{
    public interface IInventoryItemInfo
    {
        string ID { get; }
        string Title { get; }
        string Description { get; }
        Sprite SpriteIcon { get; }
        int MaxItemsInInventory { get; }
        Tier Tier { get; }
        Rarity RarityType { get; }
    }
}