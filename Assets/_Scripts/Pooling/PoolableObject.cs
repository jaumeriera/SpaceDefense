using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolableObject : MonoBehaviour
{
    protected ObjectPool pool;

    public void setPool(ObjectPool pool) {
        this.pool = pool;
    }

    protected virtual void OnDisable() {
        if (pool != null) {
            pool.addToPool(this);
        }
    }
}
