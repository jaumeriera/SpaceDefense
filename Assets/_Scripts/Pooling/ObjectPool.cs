using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField, Tooltip("Throw exception when calling GetNext of an empty pool")]
    bool ThrowErrorOnEmpty = true;

    [SerializeField] int poolSize;
    [SerializeField] PoolableObject prefab;
    [SerializeField] List<PoolableObject> pool;
    [SerializeField] List<PoolableObject> activeObj;

    void Awake() {
        pool = new List<PoolableObject>();

        for (int i = 0; i < poolSize; i++) {
            CreateElement();
        }
    }

    private PoolableObject CreateElement() {
        PoolableObject element = Instantiate(prefab);
        element.setPool(this);
        element.gameObject.SetActive(false);
        // pool.Add(element); // poolableObjects are added ondisable
        return element;
    }

    public void addToPool(PoolableObject element) {
        pool.Add(element);
        activeObj.Remove(element);
    }
    

    public PoolableObject GetNext() {
#if UNITY_EDITOR
        CheckEmptyPoolException();
#endif
        CheckEmptyPool();

        PoolableObject element = pool[0];
        pool.RemoveAt(0);
        activeObj.Add(element);
        return element;
    }

    public void CleanActiveList() {
        List<PoolableObject> tmpActive = new List<PoolableObject>(activeObj);
        foreach (PoolableObject element in tmpActive) {
            element.gameObject.SetActive(false);
        }
    }

    private void CheckEmptyPoolException() {
        if (pool.Count == 0 && ThrowErrorOnEmpty) {
            throw new Exception("Calling GetNext on empty Pool");
        }
    }

    private void CheckEmptyPool() {
        if (pool.Count == 0) {
            CreateElement();
        }
    }
}
