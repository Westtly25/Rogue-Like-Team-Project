using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.StateMachine
{
    [CreateAssetMenu(fileName = "New StateActionSO", menuName = "Rogue Like Prototype/State Machine/StateActionSO", order = 0)]
    public abstract class StateActionSO : ScriptableObject
    {
        public StateAction GetAction(StateMachine stateMachine, Dictionary<ScriptableObject, object> createdInstances)
        {
            if (createdInstances.TryGetValue(this, out var obj))
            {
				return (StateAction)obj;
            }

			var action = CreateAction();
			createdInstances.Add(this, action);
			action.StateActionSO = this;
			action.Awake(stateMachine);
			return action;
        }

		protected abstract StateAction CreateAction();
    }

    public abstract class StateActionSO<T> : StateActionSO where T : StateAction, new()
	{
		protected override StateAction CreateAction() => new T();
	}
}
