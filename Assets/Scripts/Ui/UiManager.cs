using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{
    private TaskList taskList;
    private GameObject taskCanvas;
    
    public GameObject dialogue;

    public Transform uiManager;

    void Start() {
        taskList = GameObject.Find("TaskListText").GetComponent<TaskList>();
        taskList.CreateTaskList();

        taskCanvas = GameObject.Find("TaskCanvas");
        taskCanvas.SetActive(false);
    }
    
    void Update() { 
        if (Input.GetKeyDown(KeyCode.Tab)) {
            taskCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Tab)) {
            taskCanvas.SetActive(false);
            Time.timeScale = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.K)) {
            string[] sentences = 
            { "Hey there! You're Finally Awake!", 
                "You were trying to cross the border, right?", 
                "Walked right into that Imperial ambush, same as us, and that thief over there.", 
                "Damn you Stormcloaks." };
            SpawnDialogue(sentences);
        }
    }

    private void SpawnDialogue(string[] sentences) {
        GameObject prevDialogue = GameObject.FindWithTag("Dialogue");
        if ( prevDialogue != null) {
            Debug.Log("OH NO");
            Destroy(prevDialogue);
        }
        
        dialogue = Instantiate(dialogue, uiManager);
        Dialogue init = dialogue.GetComponent<Dialogue>();
        
        init.TriggerDialogue(sentences);
    }
    
    
}