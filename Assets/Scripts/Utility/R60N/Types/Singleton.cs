using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    protected void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("[Singleton] Trying to instantiate a second instance of a singleton class");
        }
        else
        {
            Instance = (T)this;
        }
    }

    protected void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}