using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthManager))]
public class Planet : MonoBehaviour
{
    [SerializeField] int lives;
    [SerializeField] int damageReceived;
    [SerializeField] int damageForHit;
    HealthManager healthManager;

    private void Awake() {
        healthManager = GetComponent<HealthManager>();
    }
    private void Start() {
        healthManager.SetUp(lives);
        healthManager.NoHealth += Die;
    }

    private void Die() {
        // TODO implement call to gameOver
        print("die");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == (int)Layers.Enemy) {
            damageReceived += 1;
            healthManager.TakeDamage(damageReceived);
        }
    }
}
