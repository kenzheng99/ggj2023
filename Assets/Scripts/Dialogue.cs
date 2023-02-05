using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    public int AdvanceDialogue()
    {
        StopAllCoroutines();
        var len = _phases.Count;
        if (len == 0)
        {
            StartCoroutine(TypePhase(_phases.Dequeue()));
        }
        else
        {
            Destroy();
        }
        return len;
    }

    IEnumerator TypePhase(string phase)
    {
        _dialogue.text = "";
        foreach (char letter in phase.ToCharArray())
        {
            _dialogue.text += letter;
            yield return null;
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
