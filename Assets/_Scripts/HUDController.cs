using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI PlanetLiveText;
    [SerializeField] TextMeshProUGUI BombsText;

    [SerializeField] Planet planet;
    [SerializeField] SpawnProjectiles spawner;

    // Update is called once per frame
    void Update()
    {
        ScoreText.SetText(Score.score.ToString());
        PlanetLiveText.SetText(planet.GetLive().ToString());
        BombsText.SetText(spawner.bombs.ToString());
    }
}
