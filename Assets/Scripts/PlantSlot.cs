using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlot : MonoBehaviour
{
    [SerializeField] private GameObject plantPrefab;
    [SerializeField] private float verticalOffset;
    
    private Plant plant;
    private GameManager gameManager;

    void Awake() {
        gameManager = GameManager.Instance;
    }

    public void Interact() {
        if (!plant) {
            PlantNextCorpse();
        } else if (plant && plant.GetData().growth == PlantGrowth.MAXIMUM){
            Harvest();
        } else {
            Debug.Log("can't plant or harvest");
        }
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
        
        Vector3 plantPosition = transform.position + Vector3.up * verticalOffset;
        plant = Instantiate(plantPrefab, plantPosition, Quaternion.identity).GetComponent<Plant>();
        plant.SetData(plantData);
    }

    public void Grow() {
        plant.Grow();
    }

    public void Harvest() {
        gameManager.HarvestPlant(transform.GetSiblingIndex(), plant.GetData().type);
        Destroy(plant.gameObject);
    }
}
