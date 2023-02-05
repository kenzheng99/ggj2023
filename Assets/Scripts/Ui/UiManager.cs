using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{
    private GameObject taskCanvasObj;
    private GameObject dialogueObj;
    private TaskList taskList;
    private Dialogue dialogue;

    void Start() {
        taskList = GameObject.Find("TaskListTMP").GetComponent<TaskList>();
        taskList.GenerateTasks();
        taskList.FillTaskList();

        taskCanvasObj = GameObject.Find("TaskCanvas");
        taskCanvasObj.SetActive(false);

        dialogueObj = GameObject.FindWithTag("Dialogue");
        dialogue = GameObject.Find("DialogueText").GetComponent<Dialogue>();
        dialogueObj.SetActive(false);
        
    }
    
    void Update() { 
        if (Input.GetKeyDown(KeyCode.Tab)) {
            taskList.FillTaskList();
            taskCanvasObj.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Tab)) {
            taskCanvasObj.SetActive(false);
            Time.timeScale = 1;
        }
        
        string[] sentences1 = 
        { "Hey there! You're Finally Awake!", 
            "You were trying to cross the border, right?", 
            "Walked right into that Imperial ambush, same as us, and that thief over there.", 
            "Damn you Stormcloaks." };
        string[] sentences2 = 
        { "Never gonna give you up", 
            "Never gonna let you down", 
            "Never gonna run around and desert you", 
            "Never gonna make you cry",
            "Never gonna say goodbye",
            "Never gonna tell a lie and hurt you"
        };
        
        if (Input.GetKeyDown(KeyCode.K)) {
            CreateDialogue(sentences1);
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            CreateDialogue(sentences2);
        }
    }

    private void CreateDialogue(string[] sentences) {
        dialogueObj.SetActive(true);
        dialogue.TriggerDialogue(sentences);
    }


    
    
}