using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptable", menuName = "Scriptables/PlayerScriptable", order = 1)]
public class PlayerScriptable : ScriptableObject
{
    [Header("Movement")]
    public float speed;
    public float turnInclination;
}
