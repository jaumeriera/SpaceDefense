using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemySpawnerScriptable _settings;
    [SerializeField] GameObject hordeText;

    public static int scorePerEnemy;

    ObjectPool enemyPool;

    public int currentHorde;
    int spawnedEnemies;
    float currentHordeEnemies;
    float timeFromLastSpawn;

    void Awake() {
        enemyPool = GetComponent<ObjectPool>();
    }

    private void Start() {
        timeFromLastSpawn = 0;
        currentHorde = 1;
        currentHordeEnemies = _settings.firstHordeEnemies;
        scorePerEnemy = _settings.scorePerEnemy;
        StartCoroutine(SpawnHorde());
    }

    private void Update() {
        timeFromLastSpawn += Time.deltaTime;
    }


    private Vector3 GetRandomPoint() {
        float halfArea = _settings.spawnOnYLengh / 2;
        float randomY = Random.Range(-halfArea, halfArea);
        return new Vector3(gameObject.transform.position.x, randomY, 0);
    }

    private IEnumerator SpawnHorde() {
        yield return new WaitForSeconds(_settings.timeBetweenHordes);

        while(spawnedEnemies < currentHordeEnemies) {
            // This allows empty spaces between enemy ships
            
            if(timeFromLastSpawn >= _settings.timeBetweenSpawn) {
                if (MustSpawn()) {
                    SpawnEnemy();
                    spawnedEnemies += 1;
                }
                timeFromLastSpawn = 0;
            }
            yield return null;
        }
        yield return new WaitForSeconds(5);
        // increment next horde enemies
        spawnedEnemies = 0;
        currentHordeEnemies *= _settings.bonusNextHordeEnemies;
        currentHorde += 1;
        // TODO show current horde
        hordeText.SetActive(true);
        StartCoroutine(SpawnHorde());
    }

    private bool MustSpawn() {
        if(_settings.probabilityOfSpawn == 0) {
            return true;
        }
        else {
            return Random.Range(0f, 1f) < _settings.probabilityOfSpawn;
        }
    }

    private void SpawnEnemy() {
        BasicEnemy enemy = (BasicEnemy)enemyPool.GetNext();
        enemy.transform.position = GetRandomPoint();
        enemy.gameObject.SetActive(true);
    }
}
