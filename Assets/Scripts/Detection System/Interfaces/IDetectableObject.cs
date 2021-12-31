using UnityEngine;

namespace RogueLike.DetectionSystem
{
    public interface IDetectableObject
    {
        event ObjectDetectedHandler OnGameObjectDetectEvent;
        event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

        GameObject gameObject { get; }

        void Detected(GameObject detector);
        void DetectionRelesed(GameObject detector);
    }
}