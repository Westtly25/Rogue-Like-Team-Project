using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.StateMachine
{
    public class StateSO : ScriptableObject
    {
        [SerializeField] private StateActionSO[] stateActions = null;

        public State GetState(StateMachine stateMachine, Dictionary<ScriptableObject, object> createdInstances)
        {
            if (createdInstances.TryGetValue(this, out var obj))
            {
				return (State)obj;
            }

			State state = new State();

			createdInstances.Add(this, state);

			state.OriginSO = this;
			state.StateMachine = stateMachine;
			state.StateTransitions = new StateTransition[0];
			state.StateActions = GetActions(stateActions, stateMachine, createdInstances);

			return state;
        }

        private static StateAction[] GetActions(StateActionSO[] scriptableActions, StateMachine stateMachine, Dictionary<ScriptableObject, object> createdInstances)
		{
			int count = scriptableActions.Length;
			var actions = new StateAction[count];
			for (int i = 0; i < count; i++)
            {
				actions[i] = scriptableActions[i].GetAction(stateMachine, createdInstances);
            }

			return actions;
		}
    }
}