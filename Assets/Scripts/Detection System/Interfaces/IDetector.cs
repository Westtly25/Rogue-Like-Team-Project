using UnityEngine;

namespace RogueLike.DetectionSystem
{
    public delegate void ObjectDetectedHandler(GameObject detector, GameObject detectedObject);
    public interface IDetector
    {
        event ObjectDetectedHandler OnGameObjectDetectedEvent;
        event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

        void Detect(IDetectableObject detectableObject);
        void Detect(GameObject detectedObject);
        void ReleaseDetection(IDetectableObject detectableObject);
        void ReleaseDetection(GameObject detectedObject);
    }
}