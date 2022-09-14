using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthManager))]
public class Planet : MonoBehaviour
{
    [SerializeField] int lives;
    [SerializeField] int damageForHit;
    [SerializeField] GameObject gameOver;

    [SerializeField] AudioSource collisionSound;

    HealthManager healthManager;

    private void Awake() {
        healthManager = GetComponent<HealthManager>();
    }
    private void Start() {
        healthManager.SetUp(lives);
        healthManager.NoHealth += Die;
    }

    private void Die() {
        gameOver.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == (int)Layers.Enemy) {
            healthManager.TakeDamage(damageForHit);
            StartCoroutine(PlaySound());
            other.gameObject.SetActive(false);
        }
    }

    private IEnumerator PlaySound() {
        collisionSound.Play();
        yield return new WaitForSeconds(1);
    }

    public int GetLive() {
        return healthManager.GetCurrentHealth();
    }
}
