using UnityEngine;

namespace RogueLike.InventorySystem
{
    [CreateAssetMenu(fileName = "IInventoryItemInfoSO", menuName = "Rogue Like Prototype/IInventoryItemInfoSO", order = 0)]
    public class InventoryItemInfoSO : ScriptableObject, IInventoryItemInfo
    {
        [SerializeField] private string id;
        [SerializeField] private string title;
        [SerializeField] private string description;
        [SerializeField] private Sprite spriteIcon;
        [SerializeField] private int maxItemsInInventory;
        [SerializeField] private Tier tier;
        [SerializeField] private Rarity rarityType;

        public string ID => id;
        public string Title => title;
        public string Description => description;
        public Sprite SpriteIcon => spriteIcon;
        public int MaxItemsInInventory => maxItemsInInventory;
        public Tier Tier => tier;
        public Rarity RarityType => rarityType;
    }
}