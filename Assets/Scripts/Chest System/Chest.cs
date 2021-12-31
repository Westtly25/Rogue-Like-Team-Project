using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.InventorySystem;

namespace RogueLikeChestSystem
{
    public class Chest : MonoBehaviour, IChest
    {
        [SerializeField] private ChestDataSO chestDataSO;
        [SerializeField] private bool isClosed = true;

        public void DropLoot()
        {
            if (isClosed == false) { return; }

            //Instantiate();

        }
    }

    public interface IChest
    {
        void DropLoot();
    }
}

public class GroundItem : MonoBehaviour
{
    private IInventoryItem item;
    public IInventoryItem Item { get => item; private set => item = value; }
    public void Initialize(IInventoryItem item)
    {
        Item = item;
    }
}