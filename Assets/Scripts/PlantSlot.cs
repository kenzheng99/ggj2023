using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlot : MonoBehaviour
{
    [SerializeField] private GameObject plantPrefab1;
    [SerializeField] private GameObject plantPrefab2;
    [SerializeField] private GameObject plantPrefab3;
    
    private Plant plant;
    private GameManager gameManager;

    void Awake() {
        gameManager = GameManager.Instance;
    }

    public bool Interact() {
        // returns true if interaction successful
        if (!plant) {
            return PlantNextCorpse();
        } else if (plant && plant.GetData().growth == PlantGrowth.MAXIMUM){
            Harvest();
            return true;
        } else {
            Debug.Log("can't plant or harvest");
            return false;
        }
    }

    public bool PlantNextCorpse() {
        PlantData plantData = gameManager.PlantNextCorpse(transform.GetSiblingIndex());
        if (plantData == null) {
            Debug.Log("no corpses to plant");
            return false;
        }
        PlantInSlot(plantData);
        return true;
    }

    public void PlantInSlot(PlantData plantData) {
        GameObject plantPrefab;
        if (plantData.type == PlantType.PLANT1) {
            plantPrefab = plantPrefab1;
        } else if (plantData.type == PlantType.PLANT2) {
            plantPrefab = plantPrefab2;
        } else if (plantData.type == PlantType.PLANT3) {
            plantPrefab = plantPrefab3;
        } else {
            Debug.Log("PlantSlot: invalid plant type");
            return;
        }
        
        plant = Instantiate(plantPrefab, transform.position, Quaternion.identity).GetComponent<Plant>();
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
