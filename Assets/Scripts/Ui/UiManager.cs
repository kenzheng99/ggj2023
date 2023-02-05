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
        taskList = GameObject.Find("TaskListText").GetComponent<TaskList>();
        taskList.CreateTaskList();

        taskCanvasObj = GameObject.Find("TaskCanvas");
        taskCanvasObj.SetActive(false);

        dialogueObj = GameObject.FindWithTag("Dialogue");
        dialogue = GameObject.Find("DialogueText").GetComponent<Dialogue>();
        dialogueObj.SetActive(false);
        
    }
    
    void Update() { 
        if (Input.GetKeyDown(KeyCode.Tab)) {
            taskCanvasObj.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Tab)) {
            taskCanvasObj.SetActive(false);
            Time.timeScale = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.K)) {
            string[] sentences = 
            { "Hey there! You're Finally Awake!", 
                "You were trying to cross the border, right?", 
                "Walked right into that Imperial ambush, same as us, and that thief over there.", 
                "Damn you Stormcloaks." };
            dialogueObj.SetActive(true);
            dialogue.TriggerDialogue(sentences);
        }
    }


    
    
}