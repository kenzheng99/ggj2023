using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private List<PlantData> plants;
    private PlantType corpseType = PlantType.NONE;
    // TODO add other global state variables here

    public void LoadFarmScene() {
        SceneManager.LoadScene("FarmScene");
    }

    public void LoadForestScene() {
        SceneManager.LoadScene("ForestScene");
    }

    public void PlantInSlot(int slotIndex, PlantType plantType) {
        
    }
}
