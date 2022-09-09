using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonBeat : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] ButtonBeatScriptable _settings;

    private float _timeChecker = 0;
    private Color _color;

    void Start() {
        _color = buttonText.color;
    }

    void Update() {
        _timeChecker += Time.deltaTime;
        if (_timeChecker < _settings.BlinkFadeInTime) {
            buttonText.color = new Color(_color.r, _color.g, _color.b, _timeChecker / _settings.BlinkFadeInTime);
        }
        else if (_timeChecker < _settings.BlinkFadeInTime + _settings.BlinkStayTime) {
            buttonText.color = new Color(_color.r, _color.g, _color.b, 1);
        }
        else if (_timeChecker < _settings.BlinkFadeInTime + _settings.BlinkStayTime + _settings.BlinkFadeOutTime) {
            buttonText.color = new Color(_color.r, _color.g, _color.b, 1 - (_timeChecker - (_settings.BlinkFadeInTime + _settings.BlinkStayTime)) / _settings.BlinkFadeOutTime);
        }
        else {
            _timeChecker = 0;
        }
    }
}
