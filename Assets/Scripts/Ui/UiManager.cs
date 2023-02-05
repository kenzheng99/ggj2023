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
        
        // easter eggs
        string msg1 = "Hey there! You're Finally Awake!\nYou were trying to cross the border, right?\n" +
                      "Walked right into that Imperial ambush, same as us, and that thief over there.\n" +
                      "Damn you Stormcloaks.";

        string msg2 = "Never gonna give you up\nNever gonna let you down\nNever gonna run around and desert you\n" +
                      "Never gonna make you cry\nNever gonna say goodbye\never gonna tell a lie and hurt you";
        
        if (Input.GetKeyDown(KeyCode.H)) {
            CreateDialogue(msg1);
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            CreateDialogue(msg2);
        }
    }

    public void CreateDialogue(string msg) {
        dialogueObj.SetActive(true);
        dialogue.TriggerDialogue(msg);
    }


    
    
}