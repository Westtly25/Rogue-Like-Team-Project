using RogueLike.InventorySystem;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDataBaseSO", menuName = "Rogue Like Prototype/ItemsDataBaseSO", order = 0)]
public class ItemsDataBaseSO : ScriptableObject
{
    [SerializeField] private InventoryItemInfoSO[] inventoryItemInfoSOs;

    public InventoryItemInfoSO[] InventoryItemInfo { get => inventoryItemInfoSOs; }
}