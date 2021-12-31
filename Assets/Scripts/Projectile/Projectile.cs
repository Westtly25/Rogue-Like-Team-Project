using UnityEngine;

namespace RogueLike.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [Header("Projectile Components & Data")]
        [SerializeField] protected ProjectileSO projectileData;
        [SerializeField] protected MovementSO movement;
        //[SerializeField] protected Damage damage;

        [Header("Parent Data")]
        [SerializeField] protected Transform parent;
        [Header("Target Data")]
        [SerializeField] protected Transform target;

        [Header("Spawn Point")]
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private Vector3 spawnOffset;

        public virtual void Initialize(Transform parent, Transform target)
        {
            this.parent = parent;
            this.target = target;
        }

        private void OnEnable()
        {
            transform.position = parent.position;
        }
        


        void Update()
        {
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            transform.position += (target.position - transform.position).normalized * projectileData.Speed() * Time.deltaTime;

            movement.Move(transform, target, projectileData.Speed());
        }
    }
}