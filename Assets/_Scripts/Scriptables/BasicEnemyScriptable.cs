using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicEnemyScriptable", menuName = "Scriptables/BasicEnemyScriptable", order = 3)]
public class BasicEnemyScriptable : ScriptableObject
{
    [Header("Movement")]
    public float speed;
}
