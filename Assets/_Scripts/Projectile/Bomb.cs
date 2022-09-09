using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] ProjectileScriptable _settings;
    [SerializeField] ObjectPool enemyPool;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 0) {
            transform.position = new Vector3(transform.position.x + _settings.speed * Time.deltaTime, transform.position.y, 0);
        }
        else {
            PerformanceExplosion();
        }

    }

    private void PerformanceExplosion() {
        enemyPool.CleanActiveList();
        //TODO explosion sound
        gameObject.SetActive(false);
    }
}
