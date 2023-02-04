using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlots : MonoBehaviour
{
    private GameManager gameManager;
    void Start() {
        gameManager = GameManager.Instance;
        Debug.Log("PlantSlots: childCount = " + transform.childCount);
        for (int i = 0; i < transform.childCount; i++) {
            PlantData plantData = gameManager.GetPlantData(i);
            if (plantData != null) {
                transform.GetChild(i).GetComponent<PlantSlot>().PlantInSlot(plantData);
            }
        }
    }

    void Update()
    {
        
    }
}
