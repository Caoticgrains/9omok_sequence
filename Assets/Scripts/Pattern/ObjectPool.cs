using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolSize;
    // 초기 생성 개수
    private Queue<GameObject> pool;
    private static ObjectPool instance;
    public static ObjectPool Instance => instance;

    private void Awake()
    {
        instance = this;
        pool = new Queue<GameObject>();
    }

    private void CreateNewObj()
    {
        GameObject go = Instantiate(_prefab);
        Debug.Log("New object instantiated: " + go.name);
        go.SetActive(false);
        pool.Enqueue(go);
    }
    
    public GameObject GetObj()
    {
        if (pool.Count == 0)
        {
            CreateNewObj();
        }

        GameObject go = pool.Dequeue();
        Debug.Log("Object retrieved from pool: " + go.name);
        
        go.SetActive(true);
        return go;
    }

    public GameObject GetObj(Vector3 pos, Quaternion rot)
    {
        if (pool.Count == 0)
        {
            CreateNewObj();
        }
        
        GameObject go = pool.Dequeue();
        Debug.Log("Object retrieved from pool: " + go.name + " at " + pos + ", rot: " + rot);
            
        go.transform.position = pos;
        go.transform.rotation = rot;
        go.SetActive(true);
        return go;
    }

    public void ReturnObj(GameObject go)
    {
        Debug.Log("Object returned to pool: " + go.name);
        go.SetActive(false);
        pool.Enqueue(go);
    }
}
