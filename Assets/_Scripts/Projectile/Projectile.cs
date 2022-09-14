using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : PoolableObject
{
    [SerializeField] ProjectileScriptable _settings;

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x + _settings.speed * Time.deltaTime, transform.position.y, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == (int)Layers.Enemy) {
            Score.score += EnemySpawner.scorePerEnemy;
            other.gameObject.GetComponent<BasicEnemy>().DestroyShip();
            this.gameObject.SetActive(false);
        }
    }
}

