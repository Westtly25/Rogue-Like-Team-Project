using UnityEngine;
using RogueLike.Chatacters_Movement;
using RogueLike.Characteristics;
using RogueLike.InventorySystem;
using RogueLike.SpecialAbility;

namespace RogueLike.CharacterSystem
{
    [RequireComponent(typeof(PlayerMovement), typeof(CharacterisricsController), typeof(AbilitiesController))]
    public class CharacterComponent : MonoBehaviour
    {
        [SerializeField] private CharacterType characterType;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private CharacterisricsController characterisricsController;
        [SerializeField] private AbilitiesController abilitiesController;

        private void Awake() => SetComponentsField();

        private void OnEnable() => Initialize();

        public void Initialize()
        {
            playerMovement.Initialize();
            characterisricsController.Initialize();
            abilitiesController.Initialize();
        }

        private void SetComponentsField()
        {
            playerMovement = GetComponent<PlayerMovement>();
            characterisricsController = GetComponent<CharacterisricsController>();
            abilitiesController = GetComponent<AbilitiesController>();
        }
    }
}