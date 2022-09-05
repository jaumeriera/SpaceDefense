using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;

    [Header("Configuration")]
    [SerializeField] PlayerScriptable _settings;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        Score.score = 0;
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        _rigidbody.velocity = ctx.ReadValue<Vector2>() * _settings.speed;
    }

    private void OnDisable() {
        // TODO Explosion and sound and call to game over
    }
}
