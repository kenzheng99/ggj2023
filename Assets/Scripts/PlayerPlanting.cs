using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPlanting : MonoBehaviour {

    private Queue<PlantSlot> plantSlots;
    Animator anim;

    private void Start() {
        plantSlots = new Queue<PlantSlot>();
        anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PlantSlot")) {
            plantSlots.Enqueue(other.GetComponent<PlantSlot>());
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("PlantSlot")) {
            plantSlots.Dequeue();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (plantSlots.Count != 0) {
                bool interacted = plantSlots.Dequeue().Interact();
                if (interacted) {
                    anim.SetTrigger("isPlanting");
                    GameManager.Instance.PlayerMadeFirstPlant();
                    SoundManager.Instance.PlayPlantSound();
                }
            } else {
                Debug.Log("can't plant");
            }
        }
    }
}
