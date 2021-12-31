using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.InventorySystem;

namespace RogueLikeChestSystem
{
    
    [CreateAssetMenu(fileName = "ChestDataSO", menuName = "Rogue Like Prototype/Chest System/ChestDataSO", order = 0)]
    public class ChestDataSO : ScriptableObject, IChestData
    {
        [SerializeField] private ChestTypeSO chestTypeSO;
        [SerializeField] private DropChance[] dropChance;
        [SerializeField] private int[] itemsIDs;

        public ChestTypeSO ChestTypeSO { get => chestTypeSO; }
        public DropChance[] DropChance { get => dropChance;}
    }

    public interface IChestData
    {
        public ChestTypeSO ChestTypeSO { get; }
        public DropChance[] DropChance { get;}
    }

    [System.Serializable]
    public class DropChance
    {
        [SerializeField] private Rarity rarity;
        [SerializeField] private float minValueChance;
        [SerializeField] private float maxValueChance;

        public float GetRandomValue() => Random.Range(minValueChance, maxValueChance);
        public float GetMaxValue() => maxValueChance;
        public float GetMinValue() => minValueChance;
    }
}