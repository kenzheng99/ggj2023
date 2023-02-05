using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvanceDialogue : MonoBehaviour
{
    private Dialogue dialogue;
    public Button nextButton;
    
    // Start is called before the first frame update
    void Start() {
        dialogue = GameObject.Find("DialogueText").GetComponent<Dialogue>();
        nextButton.onClick.AddListener(() => Advance());
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            Advance();
        }
    }
    
    private void Advance() {
        Debug.Log(dialogue);
        var len = dialogue.AdvanceDialogue();
        if (len == 0)
        {
            Text dialogueHint = GameObject.Find("DialogueHint").GetComponent<UnityEngine.UI.Text>();
            dialogueHint.text = "Exit";
        }
    }
}
