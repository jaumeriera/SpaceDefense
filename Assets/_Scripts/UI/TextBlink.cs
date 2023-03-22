using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TMPBlink : MonoBehaviour
{
    //    TextMeshProUGUI text;
    //    float timeChecker;
    //    Color TextColor;

    //    private void Awake() {
    //        text = GetComponent<TextMeshProUGUI>();
    //    }

    //    // TODO CHJANGE THIS
    //    private void OnEnable() {
    //        timeChecker = 0;
    //        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    //        TextColor = text.color;
    //        StartCoroutine(DoBlink());
    //    }

    //    private IEnumerator DoBlink() {
    //        bool mustBlink = true;
    //        while (mustBlink) {
    //            timeChecker += Time.deltaTime;
    //            if (timeChecker < _settings.BlinkFadeInTime) {
    //                text.color = new Color(TextColor.r, TextColor.g, TextColor.b, timeChecker / _settings.BlinkFadeInTime);
    //                yield return null;
    //            }
    //            else if (timeChecker < _settings.BlinkFadeInTime + _settings.BlinkStayTime) {
    //                text.color = new Color(TextColor.r, TextColor.g, TextColor.b, 1);
    //                yield return null;
    //            }
    //            else if (timeChecker < _settings.BlinkFadeInTime + _settings.BlinkStayTime + _settings.BlinkFadeOutTime) {
    //                text.color = new Color(TextColor.r, TextColor.g, TextColor.b, 1 - (timeChecker - (_settings.BlinkFadeInTime + _settings.BlinkStayTime)) / _settings.BlinkFadeOutTime);
    //                yield return null;
    //            }
    //            else {
    //                if (!_settings.loop) {
    //                    mustBlink = false;
    //                }
    //                timeChecker = 0;
    //            }
    //        }
    //    }
}
