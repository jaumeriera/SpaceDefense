using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ButtonSaveScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI character1; 
    [SerializeField] TextMeshProUGUI character2; 
    [SerializeField] TextMeshProUGUI character3;
    public void OnClick() {
        string lowerScoreKey = PlayerPrefs.GetString(PrefLowerKeys.LowerScoreKey.ToString());
        string lowerNameKey = PlayerPrefs.GetString(PrefLowerKeys.LowerNameKey.ToString());
        if (Score.score > PlayerPrefs.GetInt(lowerScoreKey)) {
            // Save the new score in the position of lower score
            PlayerPrefs.SetInt(lowerScoreKey, Score.score);
            PlayerPrefs.SetString(lowerNameKey, BuildName());
            // Calculate new lower score
            UpdateLowerScore();
        }
        ButtonManager.MainMenu();
    }

    private string BuildName() {
        return character1.text + character2.text + character3.text;
    }

    public void UpdateLowerScore() {
        int lower = 999999999;
        PrefScoreKeys lowerKey = PrefScoreKeys.HighScore1;
        foreach(PrefScoreKeys key in PrefScoreKeys.GetValues(typeof(PrefScoreKeys))) {
            if(lower > PlayerPrefs.GetInt(key.ToString())) {
                lowerKey = key;
                lower = PlayerPrefs.GetInt(key.ToString());
            }
        }
        PlayerPrefs.SetString(PrefLowerKeys.LowerScoreKey.ToString(), lowerKey.ToString());
        PlayerPrefs.SetString(PrefLowerKeys.LowerNameKey.ToString(), ((PrefNameKeys)(int)lowerKey).ToString());


    }
}
