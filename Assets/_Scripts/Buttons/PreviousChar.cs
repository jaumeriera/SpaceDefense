using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviousChar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI character;
    private int firstChar = 65;
    private int lastChar = 90;


    public void OnClick() {
        char displayed = character.text.ToCharArray()[0];
        if ((int)displayed > firstChar) {
            displayed = (char)((int)displayed  - 1);
        }
        else {
            displayed = (char)lastChar;
        }
        character.SetText(displayed.ToString());
    }
}
