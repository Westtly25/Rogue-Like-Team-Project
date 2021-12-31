using UnityEngine;
using UnityEngine.UI;

namespace RogueLike.InventorySystem
{
    public class UIInventoryItem : UIItem
    {
        [SerializeField] private Image imageIcon;
        [SerializeField] private Text textAmount;

        public IInventoryItem item { get; private set; }

        public void Refresh(IInventorySlot inventorySlot)
        {
            if(inventorySlot.IsEmpty)
            {
                CleanUp();
                return;
            }

            item = inventorySlot.Item;
            imageIcon.sprite = item.Info.SpriteIcon;
            imageIcon.gameObject.SetActive(true);

            bool isTextAmountEnabled = inventorySlot.Amount > 1;

            textAmount.gameObject.SetActive(isTextAmountEnabled);

            if(isTextAmountEnabled)
            {
                textAmount.text = inventorySlot.Amount.ToString();
            }

        }

        private void CleanUp()
        {
            imageIcon.gameObject.SetActive(false);
            textAmount.gameObject.SetActive(false);
        }
    }
}
