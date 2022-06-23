using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singlton <T> : MonoBehaviour where T: Component
{
    private static T instance;
    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T>();
            if (instance == null)
            {
                var obj = new GameObject();
                obj.name = typeof(T).Name;
                instance = obj.AddComponent<T>();
            }
        }
        return instance;

    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            if (instance != this as T)
            {
                Destroy(gameObject);
            }
        }
    }
    
}
