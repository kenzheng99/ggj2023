using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public enum PlantType {
    PLANT1,
    PLANT2,
    PLANT3,
    NONE 
}

public enum CorpseType {
    TYPE1,
    TYPE2,
    TYPE3,
    NONE
}

public enum PlantGrowth {
    MINIMUM,
    HALF,
    MAXIMUM,
    NONE
}

public class PlantData {
    public PlantType type;
    public PlantGrowth growth;
}

public class MapSize
{
    public static float w = 13;
    public static float h = 17;
}

public class GameManager : Singleton<GameManager> {
    private Dictionary<int, PlantData> plants;
    private Queue<CorpseType> corpses;

    void Start() {
        plants = new Dictionary<int, PlantData>();
        corpses = new Queue<CorpseType>();
    }
    public void LoadFarmScene() {
        SceneManager.LoadScene("FarmScene");
    }

    public void LoadForestScene() {
        SceneManager.LoadScene("ForestScene");
    }

    public PlantData GetPlantData(int index) {
        if (plants.ContainsKey(index)) {
            return plants[index];
        }
        return null;
    }

    public void AddCorpse(CorpseType type) {
        corpses.Enqueue(type);
        Debug.Log("Corpses Carried: " + corpses.Count);
    }

    // called by PlantSlot to get the plant data to instantiate
    public PlantData PlantNextCorpse(int slotIndex) {
        if (corpses.Count == 0) {
            return null;
        }
        CorpseType corpseToPlant = corpses.Dequeue();
        print("CorpseToPlantType:" + corpseToPlant);
        PlantData data = new PlantData();
        data.type = DataUtils.ConvertCorpseTypeToPlantType(corpseToPlant);
        data.growth = PlantGrowth.MINIMUM;
        plants[slotIndex] = data;
        return data;
    }
}
