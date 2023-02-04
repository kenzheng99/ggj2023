using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public enum PlantType {
    NONE,
    PLANT1,
    PLANT2,
    PLANT3
}

public enum PlantGrowth {
    NOT_PLANTED,
    MINIMUM,
    HALF,
    MAXIMUM
}

public class PlantData {
    public PlantType type;
    public PlantGrowth growth;
}

public class GameManager : Singleton<GameManager> {
    private Dictionary<int, PlantData> plants;
    private PlantType corpseType = PlantType.NONE;

    public GameObject npc;
    // TODO add other global state variables here

    void Start() {
        if (plants == null) {
            plants = new Dictionary<int, PlantData>();
        }
    }
    public void LoadFarmScene() {
        SceneManager.LoadScene("FarmScene");
    }

    public void LoadForestScene() {
        SceneManager.LoadScene("ForestScene");
    }

    public void SetPlantData(int index, PlantType type, PlantGrowth growth) {
        PlantData data = new PlantData();
        data.type = type;
        data.growth = growth;
        plants[index] = data;
    }

    public PlantData GetPlantData(int index) {
        if (plants.ContainsKey(index)) {
            return plants[index];
        }
        return null;
    }

    public void SpawnNPC(float w, float h)
    {
        // forest has width 38 height 23
        for (int i = 0; i < Random.Range(3,6); i++)
        {
            Instantiate(npc, new Vector3(Random.Range(-w, w), Random.Range(-h, h), 0), transform.rotation);
        }
    }
}
