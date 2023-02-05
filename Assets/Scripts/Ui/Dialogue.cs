using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
    public Text dialogue;
    private Queue<string> phases;
    private GameObject dialogueParent;

    private void Start() {
        dialogueParent = GameObject.FindWithTag("Dialogue");
    }

    public void TriggerDialogue(string[] sentences) {
        StopAllCoroutines();
        dialogue.text = "";
        phases = new Queue<string>();

        foreach (string sentence in sentences) {
            phases.Enqueue(sentence);
        }

        AdvanceDialogue();
    }

    public int AdvanceDialogue() {
        StopAllCoroutines();
        if (phases.Count != 0) {
            StartCoroutine(TypePhase(phases.Dequeue()));
        }
        else {
            resetDialogue();
        }

        return phases.Count;
    }

    IEnumerator TypePhase(string phase) {
        dialogue.text = "";
        foreach (char letter in phase.ToCharArray()) {
            dialogue.text += letter;
            yield return new WaitForSeconds((float)(0.01));
        }
    }

    private void resetDialogue() {
        Text btnHint = GameObject.Find("DialogueHint").GetComponent<Text>();
        btnHint.text = "Next";
        dialogueParent.SetActive(false);
    }
}
