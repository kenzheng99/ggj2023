using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AdvanceDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public Button nextButton;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();
        nextButton.onClick.AddListener(() => Advance());
    }

    void Advance()
    {
        var len = dialogue.AdvanceDialogue();
        if (len == 1)
        {
            Text dialogueHint = GameObject.Find("DialogueHint").GetComponent<UnityEngine.UI.Text>();
            dialogueHint.text = "Exit";
        }
    }
}
