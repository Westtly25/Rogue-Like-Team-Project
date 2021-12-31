using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Helpers
{
    public abstract class ObjectPooling<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T prefab;
        [SerializeField] private bool autoExpand = false;
        [SerializeField] private Transform container;
        [SerializeField] private List<T> pool;

        public ObjectPooling(T prefab, int count)
        {
            this.prefab = prefab;
            this.container = null;

            CreatePool(count);
        }

        public ObjectPooling(T prefab, int count, Transform container)
        {
            this.prefab = prefab;
            this.container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            this.pool = new List<T>();

            for (var i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(this.prefab, this.container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            this.pool.Add(createdObject);

            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var item in pool)
            {
                if(item.gameObject.activeInHierarchy)
                {
                    element = item;
                    item.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if(HasFreeElement(out var element))
            {
                return element;
            }

            if(autoExpand)
            {
                return CreateObject(true);
            }

            throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
        }
    }
}