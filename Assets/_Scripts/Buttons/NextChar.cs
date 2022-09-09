using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextChar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI character;
    private int firstChar = 65;
    private int lastChar = 90;

    
    public void OnClick() {
        char displayed = character.text.ToCharArray()[0];
        if((int) displayed < lastChar) {
            displayed = (char)((int)displayed + 1);
        } else {
            displayed = (char)firstChar;
        }
        character.SetText(displayed.ToString());
    }
}
