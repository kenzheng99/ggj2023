using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();
    }

    void Advance()
    {
        var len = dialogue.AdvanceDialogue();
        if (len == 1)
        {
            
        }
    }
}
