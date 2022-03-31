using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Foxy.Utils
{
    public class PoolSystem<T> where T : Object
    {
        private readonly Stack<T> _stack;

        public PoolSystem(IEnumerable<T> objects)
        {
            _stack = new Stack<T>();
            foreach (var item in objects) _stack.Push(item);
        }

        public PoolSystem(int size)
        {
            _stack = new Stack<T>(size);
        }

        public T GetObjectSorted()
        {
            if (_stack.Count > 0)
            {
                var obj = _stack.Pop();
                return obj;
            }

            Debug.LogError("No objects left in the pool!");
            return null;
        }

        public T GetRandomObject()
        {
            if (_stack.Count > 0)
            {
                var array = _stack.ToArray();
                var obj = array[Random.Range(0, array.Length)];
                return obj;
            }

            Debug.LogError("No objects left in the pool!");
            return null;
        }

        public void AddToPool(T obj)
        {
            _stack.Push(obj);
        }

        public void DestroyObject(T obj, Action action)
        {
            AddToPool(obj);
            action();
        }
    }
}