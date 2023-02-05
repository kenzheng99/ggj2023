using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private Text _dialogue;
    private Queue<string> _phases;
    private bool speaking = false;

    public void TriggerDialogue(string[] sentences)
    {
        _phases = new Queue<string>();

        foreach (string sentence in sentences)
        {
            _phases.Enqueue(sentence);
        }

        speaking = true;
    }
    
}
