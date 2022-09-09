using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnProjectileScriptable", menuName = "Scriptables/SpawnProjectileScriptable", order = 4)]
public class SpawnProjectileScriptable : ScriptableObject
{
    [Header("Configuration")] 
    public float StartWaitTime;
    public float cooldown;
    public float bombCooldown;
    public int bombs;
}
