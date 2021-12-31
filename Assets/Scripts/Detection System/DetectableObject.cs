using UnityEngine;

namespace RogueLike.DetectionSystem
{
    public class DetectableObject : MonoBehaviour, IDetectableObject
    {
        public event ObjectDetectedHandler OnGameObjectDetectEvent;
        public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

        public void Detected(GameObject detector)
        {
            OnGameObjectDetectEvent?.Invoke(detector, gameObject);
        }

        public void DetectionRelesed(GameObject detector)
        {
            OnGameObjectDetectionReleasedEvent?.Invoke(detector, gameObject);
        }
    }
}