using System;

namespace RogueLike.StateMachine
{
    [Serializable]
    public class ConditionUsage
    {
        public Result ExpectedResult;
        public StateConditionSO Condition;
        public Operator Operator;
    }
}