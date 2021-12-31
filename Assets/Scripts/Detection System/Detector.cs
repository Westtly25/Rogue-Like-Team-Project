using UnityEngine;
using System.Collections.Generic;

namespace RogueLike.DetectionSystem
{
    public class Detector : MonoBehaviour, IDetector
    {
        public event ObjectDetectedHandler OnGameObjectDetectedEvent;
        public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

        [SerializeField] private List<GameObject> detectedObjects = new List<GameObject>();

        public void Detect(IDetectableObject detectableObject)
        {
            if(!detectedObjects.Contains(detectableObject.gameObject))
            {
                detectableObject.Detected(this.gameObject);
                detectedObjects.Add(detectableObject.gameObject);

                OnGameObjectDetectedEvent?.Invoke(this.gameObject, detectableObject.gameObject);
            }
        }

        public void Detect(GameObject detectedObject)
        {
            if(!detectedObjects.Contains(detectedObject))
            {
                detectedObjects.Add(detectedObject);

                OnGameObjectDetectedEvent?.Invoke(this.gameObject, detectedObject);
            }
        }

        public void ReleaseDetection(IDetectableObject detectableObject)
        {
            if(detectedObjects.Contains(detectableObject.gameObject))
            {
                detectableObject.DetectionRelesed(this.gameObject);
                detectedObjects.Remove(detectableObject.gameObject);

                OnGameObjectDetectionReleasedEvent?.Invoke(this.gameObject, detectableObject.gameObject);
            }
        }

        public void ReleaseDetection(GameObject detectedObject)
        {
            if(detectedObjects.Contains(detectedObject))
            {
                detectedObjects.Remove(detectedObject);

                OnGameObjectDetectionReleasedEvent?.Invoke(this.gameObject, detectedObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsColliderDetectableObject(other, out var detectableObject))
            {
                Debug.Log($"Object ({detectableObject.gameObject.name} detected by ({this.name}))");
                Detect(detectableObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (IsColliderDetectableObject(other, out var detectableObject))
            {
                Debug.Log($"Object ({detectableObject.gameObject.name} undetected by ({this.name}))");

                ReleaseDetection(detectableObject);
            }
        }

        private bool IsColliderDetectableObject(Collider coll, out IDetectableObject detectedObject)
        {
            detectedObject = coll.GetComponentInParent<IDetectableObject>();

            return detectedObject != null;
        }
    }
}