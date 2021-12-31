using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.StateMachine
{
    public abstract class StateConditionSO : ScriptableObject
    {
       public StateCondition GetCondition(StateMachine stateMachine, bool expectedResult, Dictionary<ScriptableObject, object> createdInstances)
       {
           if (!createdInstances.TryGetValue(this, out var obj))
			{
				var condition = CreateCondition();
				condition.StateConditionSO = this;
				createdInstances.Add(this, condition);
				condition.Awake(stateMachine);

				obj = condition;
			}

			return new StateCondition(stateMachine, (Condition)obj, expectedResult);
       }

		protected abstract Condition CreateCondition();
    }

    public abstract class StateConditionSO<T> : StateConditionSO where T : Condition, new()
	{
		protected override Condition CreateCondition() => new T();
	}
}