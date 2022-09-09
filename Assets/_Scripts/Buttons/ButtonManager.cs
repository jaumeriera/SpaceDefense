using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static void MainMenu() {
        SceneManager.DoChangeScene(Scenes.MainMenu);
    }

    public static void Play() {
        SceneManager.DoChangeScene(Scenes.Gameplay);
    }

    public static void Controls() {
        SceneManager.DoChangeScene(Scenes.Controls);
    }

    public static void LeaderBoard() {
        SceneManager.DoChangeScene(Scenes.LeaderBoard);
    }
}
