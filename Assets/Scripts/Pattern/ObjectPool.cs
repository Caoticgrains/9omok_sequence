using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    //[SerializeField] private int poolSize;

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
        GameObject go = Instantiate(Prefab);
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

    public void ReturnObj(GameObject go)
    {
        Debug.Log("Object returned to pool: " + go.name);
        go.SetActive(false);
        pool.Enqueue(go);
    }

}