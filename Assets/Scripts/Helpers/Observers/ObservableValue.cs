using System.Collections.Generic;
using UnityEngine;
using System;

namespace Helpers.Observers
{
    [Serializable]
    public class ObservableValue<T> : IObservableValue<T>
    {
        [SerializeField] private T value;

        public event Action<T> ValueChanged;
        public Type Type => typeof(T);

        public ObservableValue(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get => value;
            set
            {
                if(EqualityComparer<T>.Default.Equals(this.value, value)) { return; }
                this.value = value;
                ValueChanged?.Invoke(value);
            }
        }

        public static implicit operator T(ObservableValue<T> p)
        {
            return p.value;
        }
    }
}