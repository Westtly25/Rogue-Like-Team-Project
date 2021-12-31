using System;

namespace RogueLike.StateMachine
{
    [Serializable]
    public class TransitionItem
    {
        public StateSO FromState;
        public StateSO ToState;
        public ConditionUsage[] Conditions;
    }
}