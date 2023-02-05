using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{
    private TaskList taskList;
    private GameObject taskCanvas;

    void Start() {
        taskList = GameObject.Find("TaskListText").GetComponent<TaskList>();
        taskList.CreateTaskList();

        taskCanvas = GameObject.Find("TaskCanvas");
        taskCanvas.SetActive(false);
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            taskCanvas.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Tab)) {
            taskCanvas.SetActive(false);
        }
    }
    
    
}