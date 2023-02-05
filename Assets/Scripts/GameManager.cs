using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random=UnityEngine.Random;

public enum PlantType {
    PLANT1,
    PLANT2,
    PLANT3
}

public enum CorpseType {
    TYPE1,
    TYPE2,
    TYPE3
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
        PlantData data = new PlantData();
        
        // note this assumes that the PlantType and CorpseType enums are exactly aligned
        data.type = (PlantType) CorpseType.TYPE1;
        data.growth = PlantGrowth.MINIMUM;
        plants[slotIndex] = data;
        return data;
    }
    
    // private void CreateTaskList()
    // {
    //     List<string> names = new List<string>(new string[] 
    //         {"Jason", "Jackson", "Jamie", "Johnson", "James", "Jessica"});
    //     Tasks = "Tasks:\n\n";
    //     for (var i = 0; i < 4; i++)
    //     {
    //         Debug.Log("generate task");
    //         var idx = Random.Range(0, names.Count-1);
    //         var nameStr = names[idx];
    //         names.RemoveAt(idx);
    //         // var task = nameStr + " wants " + (Random.Range(1,10)).ToString() 
    //         //            + " type" + (Random.Range(1,3)).ToString();
    //         var task = "Harvest " + (Random.Range(1,10)).ToString() 
    //                    + " type" + (Random.Range(1,3)).ToString();
    //         Tasks += task + "\n\n";
    //     }
    // }
}
