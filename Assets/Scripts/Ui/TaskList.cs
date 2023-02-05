using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskList : MonoBehaviour
{
    public TMP_Text tasksTMP;
    private Dictionary<PlantType, int> taskDict;
    private GameManager gm;

    private void Start() {
        gm = GameManager.Instance;
    }
    
    public void GenerateTasks() {
        taskDict = new Dictionary<PlantType, int>();
        taskDict[PlantType.PLANT1] = Random.Range(2, 10);
        taskDict[PlantType.PLANT2] = Random.Range(2, 10);
        taskDict[PlantType.PLANT3] = Random.Range(2, 10);
    }
    
    public void FillTaskList() { 
        Debug.Log("Filling Task List");
        tasksTMP.text = "";
        foreach(KeyValuePair<PlantType, int> plant in taskDict)
        {
            var task = "Harvest " + plant.Value.ToString() 
                                  + " " + DataUtils.PlantToString(plant.Key)+"s";

            if (plant.Value == gm.numHarvested[plant.Key]) {
                task = "<s>" + task + "</s>";
            }
            Debug.Log(DataUtils.PlantToString(plant.Key) + " "+ gm.numHarvested[plant.Key]);
            tasksTMP.text += task + "\n";        
        }
    }
}
