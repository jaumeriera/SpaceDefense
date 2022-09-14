using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : PoolableObject
{
    [SerializeField] BasicEnemyScriptable _settings;
    [SerializeField] GameObject explosion;

    [SerializeField] AudioSource explosionSound;

    MeshRenderer renderer;
    Collider collider;

    public bool destroyed = false;

    private void Awake() {
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    private void OnEnable() {
        destroyed = false;
        renderer.enabled = true;
        collider.enabled = true;
        explosion.SetActive(false);
    }

    void Update()
    {
        if (!destroyed) {
            transform.position = new Vector3(transform.position.x - _settings.speed * Time.deltaTime, transform.position.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == (int)Layers.Player) {
            destroyed = true;
            other.GetComponent<PlayerController>().DestroyShip();
            DestroyShip();
        }
    }
    
    public void DestroyShip() {
        destroyed = true;
        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion() {
        if (destroyed) {
            explosionSound.Play();
            renderer.enabled = false;
            collider.enabled = false;
            explosion.SetActive(true);
            // play sound
            yield return new WaitForSeconds(5);
        }
        gameObject.SetActive(false);
    }
}
