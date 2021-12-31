using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.StateMachine
{
    public class State : IStateComponent
    {
        private StateSO originSO;
        private StateMachine stateMachine;
        private StateTransition[] stateTransitions;
        private StateAction[] stateActions;

        public StateSO OriginSO 
        { 
            get { return originSO; }
            set { originSO = value; }
        }

        public StateMachine StateMachine
        { 
            get { return stateMachine; }
            set { stateMachine = value; }
        }

        public StateTransition[] StateTransitions
        {
            get { return stateTransitions; }
            set { stateTransitions = value; }
        }

        public StateAction[] StateActions
        { 
            get { return stateActions; }
            set { stateActions = value; }
        }

        public State() {}

        public State(StateSO originSO, StateMachine stateMachine, StateTransition[] stateTransitions, StateAction[] stateActions)
        {
            this.originSO = originSO;
            this.stateMachine = stateMachine;
            this.stateTransitions = stateTransitions;
            this.stateActions = stateActions;
        }

        public void OnUpdate()
        {
            for (var i = 0; i < stateActions.Length; i++)
            {
                stateActions[i].OnUpdate();
            }
        }

        public void OnStateEnter()
        {
            void OnStateEnter(IStateComponent[] components)
            {
                for (int i = 0; i < components.Length; i++)
				{
					components[i].OnStateEnter();
				}

                OnStateEnter(stateTransitions);
                OnStateEnter(stateActions);
            }
        }

        public void OnStateExit()
        {
            void OnStateExit(IStateComponent[] components)
            {
                for (int i = 0; i < components.Length; i++)
				{
					components[i].OnStateExit();
				}
            }

            OnStateExit(stateTransitions);
            OnStateExit(stateActions);
        }

        public bool TryGetTransition(out State state)
		{
			state = null;

			for (int i = 0; i < stateTransitions.Length; i++)
				if (stateTransitions[i].TryGetTransiton(out state))
					break;

			for (int i = 0; i < stateTransitions.Length; i++)
				stateTransitions[i].ClearConditionsCache();

			return state != null;
		}
    }
}