using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RogueLike.StateMachine
{
    [CreateAssetMenu(fileName = "New Transition TableSO", menuName = "Rogue Like Prototype/State Machine/Transition TableSO", order = 0)]
    public class TransitionTableSO : ScriptableObject
    {
        [SerializeField] private TransitionItem[] _transitions = default;

        internal State GetInitialState(StateMachine stateMachine)
		{
			List<State> states = new List<State>();
			List<StateTransition> transitions = new List<StateTransition>();
			Dictionary<ScriptableObject, object> createdInstances = new Dictionary<ScriptableObject, object>();

			var fromStates = _transitions.GroupBy(transition => transition.FromState);

			foreach (var fromState in fromStates)
			{
				if (fromState.Key == null)
					throw new ArgumentNullException(nameof(fromState.Key), $"TransitionTable: {name}");

				var state = fromState.Key.GetState(stateMachine, createdInstances);
				states.Add(state);

				transitions.Clear();
				foreach (var transitionItem in fromState)
				{
					if (transitionItem.ToState == null)
						throw new ArgumentNullException(nameof(transitionItem.ToState), $"TransitionTable: {name}, From State: {fromState.Key.name}");

					var toState = transitionItem.ToState.GetState(stateMachine, createdInstances);
					ProcessConditionUsages(stateMachine, transitionItem.Conditions, createdInstances, out var conditions, out var resultGroups);
					transitions.Add(new StateTransition(toState, conditions, resultGroups));
				}

				state.StateTransitions = transitions.ToArray();
			}

			return states.Count > 0 ? states[0] : throw new InvalidOperationException($"TransitionTable {name} is empty.");
		}

		private static void ProcessConditionUsages(StateMachine stateMachine, ConditionUsage[] conditionUsages, Dictionary<ScriptableObject, object> createdInstances,
			                                        out StateCondition[] conditions, out int[] resultGroups)
		{
			int count = conditionUsages.Length;
			conditions = new StateCondition[count];
			for (int i = 0; i < count; i++)
            {
				conditions[i] = conditionUsages[i].Condition.GetCondition(stateMachine, conditionUsages[i].ExpectedResult == Result.True, createdInstances);
            }

			List<int> resultGroupsList = new List<int>();
			for (int i = 0; i < count; i++)
			{
				int idx = resultGroupsList.Count;
				resultGroupsList.Add(1);
				while (i < count - 1 && conditionUsages[i].Operator == Operator.And)
				{
					i++;
					resultGroupsList[idx]++;
				}
			}

			resultGroups = resultGroupsList.ToArray();
		}
    }
}