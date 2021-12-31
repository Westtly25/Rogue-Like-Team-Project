using UnityEngine;

namespace RogueLike.DetectionSystem
{
    [RequireComponent(typeof(DetectableObject))]
    public class DetectableObjectReactionIndicator : MonoBehaviour
    {
        [SerializeField] private GameObject indicator;
        [SerializeField] private bool isDetected = false;
        private IDetectableObject detectableObject;

        private void Awake() => Initialize();

        private void Initialize()
        {
            detectableObject = GetComponent<IDetectableObject>();
        }

        private void OnEnable()
        {
            detectableObject.OnGameObjectDetectEvent += OnGameObjectDetect;
            detectableObject.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
        }

        private void OnDisable()
        {
            detectableObject.OnGameObjectDetectEvent -= OnGameObjectDetect;
            detectableObject.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
        }

        private void OnGameObjectDetect(GameObject detector, GameObject detectedObject)
        {
            if (isDetected) { return; }

            ActivateIndicator();

            isDetected = true;
        }

        private void OnGameObjectDetectionReleased(GameObject detector, GameObject detectedObject)
        {
            DeactivateIndicator();

            isDetected = false;
        }

        private void ActivateIndicator()
        {
            indicator.SetActive(true);
        }

        private void DeactivateIndicator()
        {
            indicator.SetActive(false);
        }
    }
}