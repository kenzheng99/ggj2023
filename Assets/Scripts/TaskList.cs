using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    public Text tasks;

    public void CreateTaskList()
    {
        tasks.text = "";
        for (var i = 0; i < 4; i++)
        {
            var task = "Harvest " + (Random.Range(1,10)).ToString() 
                                  + " type" + (Random.Range(1,3)).ToString();
            tasks.text += task + "\n";
        }
    }
}
