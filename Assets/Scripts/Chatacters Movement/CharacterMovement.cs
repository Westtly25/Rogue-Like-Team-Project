using UnityEngine;

namespace RogueLike.Chatacters_Movement
{
    public abstract class CharacterMovement : MonoBehaviour
    {
        [SerializeField] protected float speed;
        protected Vector3 moveDirection = Vector3.zero;

        private void OnEnable()
        {
            Initialize();
        }

        public abstract void Initialize();
    }
}