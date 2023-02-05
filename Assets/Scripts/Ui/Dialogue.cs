using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
    private Text dialogue;
    private Queue<string> phases;
    private GameObject dialogueParent;

    private void Start() {
        dialogueParent = GameObject.Find("Dialogue");
    }

    public void TriggerDialogue(string[] sentences) {
        phases = new Queue<string>();

        foreach (string sentence in sentences) {
            phases.Enqueue(sentence);
        }

        AdvanceDialogue();
    }

    public int AdvanceDialogue() {
        StopAllCoroutines();
        if (phases.Count == 0) {
            StartCoroutine(TypePhase(phases.Dequeue()));
        }
        else {
            Destroy();
        }

        return phases.Count;
    }

    IEnumerator TypePhase(string phase) {
        dialogue.text = "";
        foreach (char letter in phase.ToCharArray()) {
            dialogue.text += letter;
            yield return null;
        }
    }

    void Destroy() {
        Destroy(dialogueParent);
    }
}
