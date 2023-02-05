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
    public Dictionary<PlantType, int> numHarvested;
    private UiManager UM;
    
    // player position for scene transitions
    // sorry for the hardcoding lol
    private float farmSpawnY = -16.17f;
    private float forestSpawnY = 16.45f;
    private Vector3 defaultSpawnPosition = new Vector3(2, 11.28f, 0);
    private Vector3 nextSpawnPosition;
    
    // for sound management
    public int peopleKilled;
    public bool completedFirstKill;
    public bool completedFirstPlant;
    
    // for dialogues
    private bool firstKillDialogue;
    private bool firstPlantDialogue;
    private bool startGame;

    void Start() {
        plants = new Dictionary<int, PlantData>();
        corpses = new Queue<CorpseType>();
        numHarvested = new Dictionary<PlantType, int>();
        numHarvested[PlantType.PLANT1] = 0;
        numHarvested[PlantType.PLANT2] = 0;
        numHarvested[PlantType.PLANT3] = 0;
        nextSpawnPosition = defaultSpawnPosition;

        UM = GameObject.Find("UiManager").GetComponent<UiManager>();
    }

    private void Update() {
        if (!firstKillDialogue && completedFirstKill) {
            UM.CreateDialogue("You stuff the body in your bag.");
            firstKillDialogue = true;
        } else if (!firstPlantDialogue && completedFirstPlant) {
            UM.CreateDialogue("The roots intertwine with the corpse…\nThe perfect gardening hack for fresh, fast, high quality produce!\n" +
                              "Have fun farming :)");
            firstPlantDialogue = true;
        } else if (!startGame) {
            UM.CreateDialogue("Welcome to People of the Farm! The perfectly normal farming game for perfectly normal people!\n" +
                              "Try heading down to the Forest just south of here.\nPress [Tab] to see tasks and controls.");
            startGame = true;
        } else if (true) {
        }
        
    }

    public void LoadFarmScene(float enterXPosition) {
        nextSpawnPosition = new Vector3(enterXPosition, farmSpawnY, 0);
        peopleKilled = 0;
        completedFirstKill = false;
        completedFirstPlant = false;
        SceneManager.LoadScene("FarmScene");
    }

    public void LoadForestScene(float enterXPosition) {
        nextSpawnPosition = new Vector3(enterXPosition, forestSpawnY, 0);
        SceneManager.LoadScene("ForestScene");
    }
    public Vector3 GetPlayerSpawnPosition() {
        return nextSpawnPosition;
    }
    
    public void PlayerMadeFirstKill()
    {
        if (completedFirstKill == false)
        {
            SoundManager.Instance.SwitchToKillMusic();
            completedFirstKill = true;
            // calls dialogue box "You killed someone."
        }
    }

    public void PlayerMadeFirstPlant()
    {
        if (completedFirstPlant == false)
        {
            SoundManager.Instance.SwitchToPeacefulMusic();
            completedFirstPlant = true;
            // calls dialogue box "The roots intertwine with the buried body. Great job!"
        }
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

    public void HarvestPlant(int slotIndex, PlantType type) {
        numHarvested[type] += 1;
        plants.Remove(slotIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }

    void Update() {
        Debug.Log("gamemanager update");
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("quitting");
            QuitGame();
        }
    }
}

// when layer gets kill call function in game manager
// 