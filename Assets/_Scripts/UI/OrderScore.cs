using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI name1;
    [SerializeField] TextMeshProUGUI score1;
    [SerializeField] TextMeshProUGUI name2;
    [SerializeField] TextMeshProUGUI score2;
    [SerializeField] TextMeshProUGUI name3;
    [SerializeField] TextMeshProUGUI score3;
    [SerializeField] TextMeshProUGUI name4;
    [SerializeField] TextMeshProUGUI score4;
    [SerializeField] TextMeshProUGUI name5;
    [SerializeField] TextMeshProUGUI score5;
    void Start()
    {
        SortAndAssignScores();
    }

    public void SortAndAssignScores() {
        int[] scores = new int[PrefScoreKeys.GetNames(typeof(PrefScoreKeys)).Length];
        string[] names = new string[PrefNameKeys.GetNames(typeof(PrefNameKeys)).Length];
        int i = 0;
        foreach (PrefScoreKeys key in PrefScoreKeys.GetValues(typeof(PrefScoreKeys))) {
            scores[i] = PlayerPrefs.GetInt(key.ToString());
            i += 1;
        }

        i = 0;
        foreach (PrefNameKeys key in PrefNameKeys.GetValues(typeof(PrefNameKeys))) {
            names[i] = PlayerPrefs.GetString(key.ToString());
            i += 1;
        }
        print(names[2]);
        print(scores[2]);
        // Scores are the keys to order and the names are the items
        System.Array.Sort(scores, names);
        DoAssign(names, scores);
    }

    private void DoAssign(string[] names, int[] scores) {
        name1.SetText(names[4]);
        score1.SetText(scores[4].ToString());
        name2.SetText(names[3]);
        score2.SetText(scores[3].ToString());
        name3.SetText(names[2]);
        score3.SetText(scores[2].ToString());
        name4.SetText(names[1]);
        score4.SetText(scores[1].ToString());
        name5.SetText(names[0]);
        score5.SetText(scores[0].ToString());
    }

}
