using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
		[SerializeField] private TransitionTableSO _transitionTableSO = default;
        
        private readonly Dictionary<Type, Component> _cachedComponents = new Dictionary<Type, Component>();
		internal State _currentState;

        private void Awake()
		{
			_currentState = _transitionTableSO.GetInitialState(this);
		}

        private void Start()
		{
			_currentState.OnStateEnter();
		}

		public new bool TryGetComponent<T>(out T component) where T : Component
		{
			var type = typeof(T);

			if (!_cachedComponents.TryGetValue(type, out var value))
			{
				if (base.TryGetComponent<T>(out component))
				{
					_cachedComponents.Add(type, component);
				}

				return component != null;
			}

			component = (T)value;
			return true;
		}

		public T GetOrAddComponent<T>() where T : Component
		{
			if (!TryGetComponent<T>(out var component))
			{
				component = gameObject.AddComponent<T>();
				_cachedComponents.Add(typeof(T), component);
			}

			return component;
		}

		public new T GetComponent<T>() where T : Component
		{
			return TryGetComponent(out T component) ? component : throw new InvalidOperationException($"{typeof(T).Name} not found in {name}.");
		}

		private void Update()
		{
			if (_currentState.TryGetTransition(out var transitionState))
			{
				Transition(transitionState);
			}

			_currentState.OnUpdate();
		}

		private void Transition(State transitionState)
		{
			_currentState.OnStateExit();
			_currentState = transitionState;
			_currentState.OnStateEnter();
		}
    }
}