using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.SetText("Your final score is " + Score.score.ToString());
        spawner.SetActive(false);
    }

}
