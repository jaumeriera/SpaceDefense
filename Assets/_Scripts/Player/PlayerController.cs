using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;
    MeshRenderer renderer;
    Collider collider;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject explosion;
    [SerializeField] List<GameObject> toDeactivate;

    [Header("Configuration")]
    [SerializeField] PlayerScriptable _settings;

    bool destroyed;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
        destroyed = false;
    }

    private void Start() {
        Score.score = 0;
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        if (!destroyed) {
            _rigidbody.velocity = ctx.ReadValue<Vector2>() * _settings.speed;
        }
    }

    public void DestroyShip() {
        destroyed = true;
        StartCoroutine(Explosion());
    }
    private IEnumerator Explosion() {

        renderer.enabled = false;
        collider.enabled = false;
        foreach(GameObject element in toDeactivate) {
            element.SetActive(false);
        }
        explosion.SetActive(true);
        gameOver.SetActive(true);
        // play sound
        yield return new WaitForSeconds(5);

        gameObject.SetActive(false);
    }
}
