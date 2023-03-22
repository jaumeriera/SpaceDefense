using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLeaderScore : MonoBehaviour
{
    void Start() {
        if (!PlayerPrefs.HasKey(PrefLowerKeys.LowerNameKey.ToString())) {
            foreach (PrefScoreKeys key in PrefScoreKeys.GetValues(typeof(PrefScoreKeys))) {
                PlayerPrefs.SetInt(key.ToString(), 0);
            }
            foreach (PrefNameKeys key in PrefNameKeys.GetValues(typeof(PrefNameKeys))) {
                PlayerPrefs.SetString(key.ToString(), "AAA");
            }
            PlayerPrefs.SetString(PrefLowerKeys.LowerNameKey.ToString(), PrefNameKeys.HighName1.ToString());
            PlayerPrefs.SetString(PrefLowerKeys.LowerScoreKey.ToString(), PrefScoreKeys.HighScore1.ToString());
        }
    }


}
