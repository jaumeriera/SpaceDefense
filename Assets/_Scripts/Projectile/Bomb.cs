using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] ProjectileScriptable _settings;
    [SerializeField] ObjectPool enemyPool;

    [SerializeField] AudioSource shot;
    [SerializeField] AudioSource explosion;

    bool explode;

    private void OnEnable() {
        explode = false;
        shot.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 0) {
            transform.position = new Vector3(transform.position.x + _settings.speed * Time.deltaTime, transform.position.y, 0);
        }
        else if(!explode) {
            explode = true;
            PerformanceExplosion();
        }

    }

    private void PerformanceExplosion() {
        List<PoolableObject> enemies = enemyPool.GetActiveElements();
        Score.score += enemies.Count * EnemySpawner.scorePerEnemy;

        foreach (BasicEnemy enemy in enemies) {
            enemy.DestroyShip();
        }

        StartCoroutine(PlaySound());
    }

    private IEnumerator PlaySound() {
        shot.Stop();
        explosion.Play();
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
