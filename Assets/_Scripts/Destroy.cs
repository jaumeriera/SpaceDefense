using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] Layers layer;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == (int)layer) {
            other.gameObject.SetActive(false);
        }
    }
}
