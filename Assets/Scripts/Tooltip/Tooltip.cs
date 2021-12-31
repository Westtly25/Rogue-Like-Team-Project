using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace RogueLike.Tooltip
{
    public class Tooltip : MonoBehaviour
    {
        public Text headerField;
        public Text contentField;

        public LayoutElement layoutElement;

        public RectTransform rectTransform;

        public int characterWrapLimit;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

         public void SetText(string content, string header = "")
        {
            if(string.IsNullOrEmpty(header))
            {
                headerField.gameObject.SetActive(false);
            }
            else
            {
                headerField.gameObject.SetActive(true);
                headerField.text = header;
            }

            contentField.text = content;

            UpdateTooltip();
        }

        private void UpdateTooltip()
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;


            Vector2 position = Mouse.current.position.ReadValue();

            float pivotX = position.x / Screen.width;
            float pivotY = position.y / Screen.height;

            rectTransform.pivot = new Vector2(pivotX, pivotY);

            transform.position = position;
        }
    }
}