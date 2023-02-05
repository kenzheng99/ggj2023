using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpawn : MonoBehaviour
{
    public GameObject DialogueBox, AdvanceDialogue, DialogueHint;

    public void SpawnDialogue()
    {
        Debug.Log("OMG");
        Instantiate(DialogueBox);
    }
    // Start is called before the first frame update
    void Start()
    {
        string[] sentences = 
            { "Hey there! You're Finally Awake!", 
                "You were trying to cross the border, right?", 
                "Walked right into that Imperial ambush, same as us, and that thief over there.", 
                "Damn you Stormcloaks." };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
