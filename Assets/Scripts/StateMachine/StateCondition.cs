using UnityEngine;

namespace RogueLike.StateMachine
{
    public readonly struct StateCondition
    {
        [SerializeField] private readonly StateMachine stateMachine;

        [SerializeField] private readonly Condition condition;

        [SerializeField] private readonly bool expectedResult;

        public Condition GetCondition => condition;

        public StateCondition(StateMachine stateMachine, Condition condition, bool expectedResult)
        {
            this.stateMachine = stateMachine;
            this.condition = condition;
            this.expectedResult = expectedResult;
        }

        public bool IsMet()
        {
            bool statement = condition.GetStatement();
			bool isMet = statement == expectedResult;

            return isMet;
        }
    }
}