using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ButtonBeatScriptable", menuName = "Scriptables/ButtonBeatScriptable", order = 6)]
public class ButtonBeatScriptable : ScriptableObject
{
    public float BlinkFadeInTime;
    public float BlinkStayTime;
    public float BlinkFadeOutTime;

}
