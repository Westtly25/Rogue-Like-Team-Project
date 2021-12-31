using UnityEngine;

namespace RogueLike.Combat
{
    [CreateAssetMenu(fileName = "ScriptableTargetFinder", menuName = "Rogue Like Prototype/Combat/Target Finders/ScriptableTargetFinder", order = 0)]
    public class ScriptableTargetFinder : ScriptableObject 
    {
        [Header("TARGET LAYER DETECTION")]
        public LayerMask targetLayerMask;

        [Header("OBSTACLES LAYER DETECTION")]
        public LayerMask obstacleLayerMask;

        [Header("TARGETING PARAMS")] [Range(0, 20)]
        [SerializeField] protected float viewRadius = 5f;

        [Range(0, 360)]
        [SerializeField] protected float viewAngle = 360f;

        [Range(1, 10)]
        [SerializeField] private int maxTargets;

        
        private GameObject parent;


        public void SetParent(GameObject parent)
        {
            this.parent = parent;
        }

        public void FindTarget()
        {
            
        }

        private Vector3 DirectionFromVector(float angle)
        {
            return new Vector3(Mathf.Sign(angle * Mathf.Deg2Rad), 0f, Mathf.Cos(angle * Mathf.Deg2Rad));
        }
    }
}