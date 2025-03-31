using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
    public class ObjectPool9 : MonoBehaviour
    {
        private Queue<GameObject> _pool = new Queue<GameObject>();
        private GameObject _prefab;
        private Transform _parent;
        private int _size;

        public void Initialize(GameObject prefab, int initialSize, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;
            _size = initialSize;

            for (int i = 0; i < initialSize; i++)
            {
                GameObject obj = Instantiate(_prefab, _parent);
                obj.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        public GameObject GetObj()
        {
            if (_pool.Count > 0)
            {
                GameObject obj = _pool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            else
            {
                return Instantiate(_prefab, _parent);
            }
        }

        public void ReturnObj(GameObject obj)
        {
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}
