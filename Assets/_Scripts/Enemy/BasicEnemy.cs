using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : PoolableObject
{
    [SerializeField] BasicEnemyScriptable _settings;

    void Update()
    {
        transform.position = new Vector3(transform.position.x - _settings.speed * Time.deltaTime, transform.position.y, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == (int)Layers.Player) {
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    protected override void OnDisable() {
        base.OnDisable();
        // Explode effect and sound
    }
}
