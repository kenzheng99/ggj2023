using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlot : MonoBehaviour
{
    [SerializeField] private GameObject plantPrefab;
    [SerializeField] private float verticalOffset;
    
    private GameObject plant;
    private GameManager gameManager;

    void Awake() {
        gameManager = GameManager.Instance;
    }

    public void PlantNextCorpse() {
        PlantData plantData = gameManager.PlantNextCorpse(transform.GetSiblingIndex());
        if (plantData == null) {
            Debug.Log("no corpses to plant");
            return;
        }
        PlantInSlot(plantData);
    }

    public void PlantInSlot(PlantData plantData) {
        if (plant) {
            return;
        }
        
        Vector3 plantPosition = transform.position + Vector3.up * verticalOffset;
        plant = Instantiate(plantPrefab, plantPosition, Quaternion.identity);
        plant.GetComponent<Plant>().SetData(plantData);
    }

    public void Grow() {
        plant.GetComponent<Plant>().Grow();
    }
}
