using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.StateMachine
{
    public abstract class StateAction : IStateComponent
    {
        [SerializeField] private StateActionSO stateActionSO;

        public StateActionSO StateActionSO
        {
            get { return stateActionSO; }
            set { stateActionSO = value; }
        }

        public virtual void Awake(StateMachine stateMachine) { }
        public abstract void OnUpdate();
        


        public virtual void OnStateEnter()
        {

        }

        public virtual void OnStateExit()
        {

        }

        public enum SpecificMoment
		{
			OnStateEnter, OnStateExit, OnUpdate,
		}
    }
}