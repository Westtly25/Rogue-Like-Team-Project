using UnityEngine;

namespace RogueLike.AI
{
    public class StateController : MonoBehaviour
    {
        [SerializeField] State currentState;
        [SerializeField] State remainState;
        [SerializeField] float stateTimeElapsed;

        [Space]
        [SerializeField] public Vector3 startingPosition;
        [SerializeField] public Vector3 roamingPosition;

        //[HideInInspector] public NavMeshAgent navMeshAgent;
        //[SerializeField] public Mover mover;
        //[SerializeField] public FighterAI fighterAI;
        //[SerializeField] public Health health;


        private void Awake()
        {
            //navMeshAgent = GetComponent<NavMeshAgent>();
            //fighterAI = GetComponent<FighterAI>();
            //mover = GetComponent<Mover>();
            //health = GetComponent<Health>();
        }

        private void Start()
        {
            startingPosition = SetStartingPosition();
            roamingPosition = GetRoamingPosition();
        }

        private void Update()
        {
            //if (health.IsDead()) { return; }

            currentState.UpdateState(this);
        }

        public void TransitionToState(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
            }
        }

        public bool ChackIfCountDownElapse(float duration)
        {
            stateTimeElapsed += Time.deltaTime;
            return stateTimeElapsed >= duration;
        }

        private void OnExitState()
        {
            stateTimeElapsed = 0;
        }

        public Vector3 SetStartingPosition()
        {
            return transform.position;
        }

        public Vector3 GetRoamingPosition()
        {
            return startingPosition + GetRandomDirection() * Random.Range(5f, 10f);
        }

        public static Vector3 GetRandomDirection()
        {
            return new Vector3(Random.Range(-1f, 1f), 0f, (Random.Range(-1f, 1f))).normalized;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, 10f);
        }
    }
}