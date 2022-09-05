using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileScriptable", menuName = "Scriptables/ProjectileScriptable", order = 2)]
public class ProjectileScriptable : ScriptableObject
{
    [Header("Movement")]
    public float speed;
}
