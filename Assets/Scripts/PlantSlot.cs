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

    public void PlantInSlot() {
        if (!plant) {
            Vector3 plantPosition = transform.position + Vector3.up * verticalOffset;
            plant = Instantiate(plantPrefab, plantPosition, Quaternion.identity);
            gameManager.SetPlantData(transform.GetSiblingIndex(), PlantType.PLANT1, PlantGrowth.MINIMUM);
        }
    }
}
