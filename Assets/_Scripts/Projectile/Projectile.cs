using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : PoolableObject
{
    [SerializeField] ProjectileScriptable _settings;
    private float speed = 50;

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == (int)Layers.Enemy) {
            Score.score += EnemySpawner.scorePerEnemy;
            print(Score.score);
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}

