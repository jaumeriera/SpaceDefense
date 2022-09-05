using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class SpawnProjectiles : MonoBehaviour
{
    [SerializeField] SpawnProjectileScriptable _settings;

    ObjectPool playerProjectilesPool;

    float timeFromLastSpawn;
    bool shooting;
    //Coroutine ShootProjectilesReference;

    void Awake() {
        playerProjectilesPool = GetComponent<ObjectPool>();
    }

    void Start()
    {
        timeFromLastSpawn = -_settings.StartWaitTime;
    }

    private void Update() {
        timeFromLastSpawn += Time.deltaTime;

        // This lines could be removed if coroutines works
        if (shooting && timeFromLastSpawn >= _settings.cooldown) {
            SpawnProjectile();
            timeFromLastSpawn = 0f;
        }
    }

    public void OnFire(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            //ShootProjectilesReference = StartCoroutine(ShootProjectiles());
            shooting = true;
        } else if (ctx.canceled) {
            shooting = false;
            //StopCoroutine(ShootProjectilesReference);
        }

    }

    // I dont know why but this function makes unity crash 
    private IEnumerator ShootProjectiles() {
        while (true) {
            if (timeFromLastSpawn >= _settings.cooldown) {
                SpawnProjectile();
                timeFromLastSpawn = 0f;
                yield return new WaitForSeconds(_settings.cooldown);
            }
        }
    }

    private void SpawnProjectile() {
        Projectile projectile = (Projectile)playerProjectilesPool.GetNext();
        projectile.transform.position = gameObject.transform.position;
        projectile.gameObject.SetActive(true);
    }
}
