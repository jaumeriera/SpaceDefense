using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerScriptable", menuName = "Scriptables/EnemySpawnerScriptable", order = 5)]
public class EnemySpawnerScriptable : ScriptableObject
{
    [Tooltip("This is the height of all spawn zone")]
    [Header("Space Spawner")]
    public float spawnOnYLengh;

    [Header("Time related configurations")]
    public float timeBetweenHordes;
    public float timeBetweenSpawn;

    [Header("Enemy configuration")]
    public int scorePerEnemy;

    [Header("Other configuration")]
    [Tooltip("This is the probability of spawn an enemy")]
    [Range(0, 1)]
    public float probabilityOfSpawn;
    [Range(1,30)]
    public int firstHordeEnemies;
    [Range(1,2)]
    public float bonusNextHordeEnemies;


}
