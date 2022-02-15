using UnityEngine;
using UnityEngine.InputSystem;

namespace RogueLike.Chatacters_Movement
{
    [RequireComponent(typeof(CharacterController), typeof(Rigidbody))]
    public class PlayerMovement : CharacterMovement, IMovement
    {
        [SerializeField] private Rigidbody rigidbodyCharacter;
        private CharacterController characterController;
        private CharacterInputAction characterInput;
        private InputAction inputAction;

        private float desiredRotationAngle;

        //TODO Вынестив отдельный класс Инпута
        private Camera mainCamera;

        [SerializeField] float rotationSpeed = 2f;
        private Vector3 forward;
        private Vector3 right;

        private void Awake()
        {
            rigidbodyCharacter = GetComponent<Rigidbody>();
            characterController = GetComponent<CharacterController>();
            mainCamera = Camera.main;
            SetDirectionByCamera();
        }

        private void OnDisable()
        {
            inputAction.Disable();
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        public override void Initialize()
        {
            characterController = GetComponent<CharacterController>();

            characterInput = new CharacterInputAction();

            inputAction = characterInput.Player.Movement;

            inputAction.Enable();
        }

        //TODO Вынестив отдельный класс Инпута
        private void SetDirectionByCamera()
        {
            forward = mainCamera.transform.forward;
            right = mainCamera.transform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();
        }

        public void Move()
        {
            moveDirection = right * inputAction.ReadValue<Vector2>().x + forward * inputAction.ReadValue<Vector2>().y;
            characterController.Move(new Vector3(moveDirection.x, -9.16f, moveDirection.z) * speed * Time.deltaTime);
        }

        private void Rotate()
        {

            var angel = Vector3.Angle(transform.forward, moveDirection);
            var crossProduct = Vector3.Cross(transform.forward, moveDirection).y;

            if(crossProduct < 0)
            {
                angel *= -1;
            }

            if(angel > 10 || angel < -10)
            {
                transform.Rotate(Vector3.up * angel * rotationSpeed * Time.deltaTime);
            }
        }
    }
}