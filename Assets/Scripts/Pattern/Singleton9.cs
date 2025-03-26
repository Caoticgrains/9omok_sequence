using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Singleton9<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();
    private static int serialCounter = 0;
    private static Dictionary<string, int> _singletonMapCount = new Dictionary<string, int>();
    private int serialNumber;
    
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = FindObjectOfType<T>();

                        if (_instance == null)
                        {
                            GameObject obj = new GameObject
                            {
                                name = typeof(T).Name
                            };
                            _instance = obj.AddComponent<T>();
                        }
                    }
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;    // 씬 전환시 호출되는 액션 메서드 할당
            serialNumber = serialCounter++; // 시리얼넘버 할당
            string sceneName = SceneManager.GetActiveScene().name; // 현재 씬에서 싱글톤 갯수 증가
            
            if(!_singletonMapCount.TryAdd(sceneName, 1))
                _singletonMapCount[sceneName]++;
            else
                _singletonMapCount[sceneName] = 1;
            
            DebugSingletonInstances();
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            
            // 현재씬에서 싱글톤 갯수 감소 
            string sceneName = SceneManager.GetActiveScene().name;
            if (_singletonMapCount.ContainsKey(sceneName))
            {
                _singletonMapCount[sceneName]--;
                if(_singletonMapCount[sceneName] <= 0)
                    _singletonMapCount.Remove(sceneName);
            }
            DebugSingletonInstances();
        }
    }
    
    protected abstract void OnSceneLoaded(Scene scene, LoadSceneMode mode);
    
    // 모든 씬에서 살아있는 싱글톤 객체 개수를 확인한다. 
    private void DebugSingletonInstances()
    {
        Debug.Log($"[{typeof(T).Name}] (ID: {serialNumber}) is in scene '{SceneManager.GetActiveScene().name}'");
        Debug.Log("=== Current Singleton Instances ===");
        foreach (var kvp in _singletonMapCount)
        {
            Debug.Log($"Scene: {kvp.Key}, {typeof(T).Name} Count: {kvp.Value}");
        }
    }
}
