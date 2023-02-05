using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerPlanting : MonoBehaviour {

    private PlantSlot plantSlot;
    Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PlantSlot")) {
            plantSlot = other.GetComponent<PlantSlot>();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("PlantSlot")) {
            plantSlot = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (plantSlot) {
                //attach plant/harvest SFX audio source to the player
                plantSlot.Interact();
                anim.SetTrigger("isPlanting");
                GameManager.Instance.PlayerMadeFirstPlant();
            } else {
                Debug.Log("can't plant");
            }
        }
    }
}
