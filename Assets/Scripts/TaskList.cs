using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    public Text tasks;
    
    public void CreateTaskList()
    {
        // List<string> names = new List<string>(new string[] 
        //     {"Jason", "Jackson", "Jamie", "Johnson", "James", "Jessica"});
        tasks.text = "Tasks:\n\n";
        for (var i = 0; i < 4; i++)
        {
            // var idx = Random.Range(0, names.Count-1);
            // var nameStr = names[idx];
            // names.RemoveAt(idx);
            // var task = nameStr + " wants " + (Random.Range(1,10)).ToString() 
            //            + " type" + (Random.Range(1,3)).ToString();
            var task = "Harvest " + (Random.Range(1,10)).ToString() 
                       + " type" + (Random.Range(1,3)).ToString();
            tasks.text += task + "\n\n";
        }
    }
}
