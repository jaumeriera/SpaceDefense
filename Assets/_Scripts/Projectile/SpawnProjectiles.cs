using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class SpawnProjectiles : MonoBehaviour
{
    [SerializeField] SpawnProjectileScriptable _settings;

    ObjectPool playerProjectilesPool;
    [SerializeField] GameObject bombObject;

    float timeFromLastSpawn;
    float timeFromLastBomb;
    bool shooting;
    public int bombs;
    //Coroutine ShootProjectilesReference;

    void Awake() {
        playerProjectilesPool = GetComponent<ObjectPool>();
    }

    void Start()
    {
        bombs = _settings.bombs;
        timeFromLastSpawn = -_settings.StartWaitTime;
    }

    private void Update() {
        timeFromLastSpawn += Time.deltaTime;
        timeFromLastBomb += Time.deltaTime;

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

    public void OnFire2(InputAction.CallbackContext ctx) {
        
        if (ctx.performed && timeFromLastBomb > _settings.bombCooldown) {
            if (bombs > 0) {
                bombs -= 1;
                SpawnBomb();
                timeFromLastBomb = 0;
            }
            else {
                // TODO implement sound empty ammo
            }
        }
    }

    private void SpawnBomb() {
        bombObject.transform.position = gameObject.transform.position;
        bombObject.SetActive(true);
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
