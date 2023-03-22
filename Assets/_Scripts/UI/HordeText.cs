using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HordeText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hordeText;
    [SerializeField] ButtonBeatScriptable _settings;
    [SerializeField] EnemySpawner spawner;

    private float _timeChecker = 0;
    private Color _color;
    void Start()
    {
    }

    private void OnEnable() {
        hordeText.color = new Color(1, 1, 1, 1);
        _color = hordeText.color;
        hordeText.SetText("Wave " + spawner.currentHorde.ToString());
        StartCoroutine(ShowCurrentHorde());
    }

    private IEnumerator ShowCurrentHorde() {
        bool end = false;
        while (!end) {
            _timeChecker += Time.deltaTime;
            if (_timeChecker < _settings.BlinkFadeInTime) {
                hordeText.color = new Color(_color.r, _color.g, _color.b, _timeChecker / _settings.BlinkFadeInTime);
                yield return null;
            }
            else if (_timeChecker < _settings.BlinkFadeInTime + _settings.BlinkStayTime) {
                hordeText.color = new Color(_color.r, _color.g, _color.b, 1);
                yield return null;
            }
            else if (_timeChecker < _settings.BlinkFadeInTime + _settings.BlinkStayTime + _settings.BlinkFadeOutTime) {
                hordeText.color = new Color(_color.r, _color.g, _color.b, 1 - (_timeChecker - (_settings.BlinkFadeInTime + _settings.BlinkStayTime)) / _settings.BlinkFadeOutTime);
                yield return null;
            }
            else {
                end = true;
                _timeChecker = 0;
            }
        }
        gameObject.SetActive(false);
    }

}
