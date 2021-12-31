using UnityEngine;

namespace RogueLike.StateMachine
{
    public abstract class Condition : IStateComponent
    {
        private bool isCached = false;
		private bool cachedStatement = default;

        [SerializeField] StateConditionSO stateConditionSO;

        public StateConditionSO StateConditionSO
        {
            get { return stateConditionSO; }
            set { stateConditionSO = value; }
        }

        protected abstract bool Statement();

        public bool GetStatement()
        {
            if(!isCached)
            {
                isCached = true;
                cachedStatement = Statement();
            }

			return cachedStatement;
        }

        public void ClearStatementCache()
        {
            isCached = false;
        }

        public virtual void Awake(StateMachine stateMachine) { }
		public virtual void OnStateEnter() { }
		public virtual void OnStateExit() { }
    }
}