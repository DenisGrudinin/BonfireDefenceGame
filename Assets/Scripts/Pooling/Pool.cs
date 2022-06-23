using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] PoolObject prefab;
    Transform container;
    [SerializeField] int minCapacity;
    [SerializeField] int maxCapacity;
    [SerializeField] bool autoExpand; 
    List<PoolObject> pool;

    public void Start()
    {
        CreatePool();
    }

    public void OnValidate()
    {
        if (autoExpand)
        {
            maxCapacity = int.MaxValue;
        }
    }

    public void CreatePool()
    {
        pool = new List<PoolObject>(minCapacity);
        for (int i = 0; i < minCapacity; i++)
        {
            CreateElement();
        }
    }

    public PoolObject CreateElement(bool isActiveByDefault = false)
    {
        var createdObject = Instantiate(prefab, container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        pool.Add(createdObject);
        return createdObject;
    }

    public bool TryGetElement(out PoolObject element)
    {
        for (int i = pool.Count - 1; i >= 0; i--)
        {
            if (pool[i] == null)
            {
                pool.RemoveAt(i);
            }
          
            else 
            {
                if (!pool[i].gameObject.activeInHierarchy)
                {
                    element = pool[i];
                    pool[i].gameObject.SetActive(true);
                    return true;
                }
            }
        }
        element = null;
        return false;
    }

    public PoolObject GetFreeElement(Vector3 position, Quaternion rotation)
    {
        var element = GetFreeElement(position);
        element.transform.rotation = rotation;
        return element;
    }

    public PoolObject GetFreeElement(Vector3 position)
    {
        var element = GetFreeElement();
        element.transform.position = position;
        return element;
    }

    public PoolObject GetFreeElement()
    {
        if (TryGetElement(out var element))
        {
            return element;
        }
        if (autoExpand)
        {
            return CreateElement(true);
        }
        if (pool.Count < maxCapacity)
        {
            return CreateElement(true);
        }
        throw new System.Exception("Pool is over!");
    }

    public void ClearPool()
    {
        pool.Clear();
    }
}
