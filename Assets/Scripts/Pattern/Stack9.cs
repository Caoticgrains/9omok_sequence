using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
    public class Stack9<T> : MonoBehaviour
    {
        public List<T> _items = new();

        public void Push(T obj)
        {
            _items.Add(obj);
        }

        public T Pop()
        {
            if (_items.Count > 0)
            {
                T obj = _items[^1];
                _items.RemoveAt(_items.Count - 1);
                return obj;
            }
            else
            {
                throw new System.Exception("Stack is empty");
            }
        }

        public bool IsEmpty()
        {
            return _items.Count == 0;
        }

        public T Peek()
        {
            if (_items.Count > 0)
            {
                return _items[^1];
            }
            else
            {
                throw new System.Exception("Stack is empty");
            }
        }

        public int Count()
        {
            return _items.Count;
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}
