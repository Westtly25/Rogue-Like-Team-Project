using UnityEngine;
using UnityEngine.AI;

namespace RogueLike.Chatacters_Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPCMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;

        [SerializeField] private PlayerMovement targetPosition;
        public PlayerMovement TargetPosition
        { 
            set
            {
                if(value == null) { return; }

                targetPosition = value;
            }
        }

        public void Initialize()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Awake()
        {
            Initialize();
        }

        private void Update() 
        {
            Move();
        }

        public void Move()
        {
            if(agent.isOnNavMesh)
            {
                agent.destination = targetPosition.gameObject.transform.position;
            }
        }
    }
}