using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerPlanting : MonoBehaviour {

    private Collider2D plantSlot;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PlantSlot")) {
            plantSlot = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("PlantSlot")) {
            plantSlot = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (plantSlot) {
                Debug.Log("plant");
                plantSlot.gameObject.GetComponent<PlantSlot>().PlantInSlot();
            } else {
                Debug.Log("can't plant");
            }
        }
    }
}
