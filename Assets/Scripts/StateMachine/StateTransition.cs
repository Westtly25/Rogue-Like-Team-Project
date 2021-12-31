using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.StateMachine
{
    public class StateTransition : IStateComponent
    {
        private State targetState;
        private StateCondition[] conditions;
        private int[] resultGroups;
        private bool[] results;

        public StateTransition() { }
        public StateTransition(State targetState, StateCondition[] conditions, int[] resultGroups = null)
        {
            this.targetState = targetState;
            this.conditions = conditions;
            this.resultGroups = resultGroups != null && resultGroups.Length > 0 ? resultGroups : new int[1];
			results = new bool[resultGroups.Length];
        }

        public virtual void OnStateEnter()
        {
            for (var i = 0; i < conditions.Length; i++)
            {
                conditions[i].GetCondition.OnStateEnter();
            }
        }

        public virtual void OnStateExit()
        {
            for (var i = 0; i < conditions.Length; i++)
            {
                conditions[i].GetCondition.OnStateExit();
            }
        }

        public bool TryGetTransiton(out State state)
		{
			state = ShouldTransition() ? targetState : null;
			return state != null;
		}

        private bool ShouldTransition()
		{
            int count = resultGroups.Length;
			for (int i = 0, idx = 0; i < count && idx < conditions.Length; i++)
            {
                for (int j = 0; j < resultGroups[i]; j++, idx++)
                {
                    results[i] = j == 0 ? conditions[idx].IsMet() : results[i] && conditions[idx].IsMet();
                }
            }

			bool ret = false;

			for (int i = 0; i < count && !ret; i++)
            {
				ret = ret || results[i];
            }
                
            return ret;
        }

        public void ClearConditionsCache()
		{
			for (int i = 0; i < conditions.Length; i++)
            {
				conditions[i].GetCondition.ClearStatementCache();
            }
		}
    }
}