using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{
    private TaskList taskList;
    void Start()
    {
        taskList = GameObject.Find("TaskList").GetComponent<TaskList>();
        taskList.CreateTaskList();
    }
}
