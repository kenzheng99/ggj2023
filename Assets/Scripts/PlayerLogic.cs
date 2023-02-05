using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private bool _canKill;
    public npcLogic npc;
    private GameManager gameManager;
    private UiManager UM;
    Animator anim;

    private bool firstInteract;

    // private Collision2D NPC;
    
    // Start is called before the first frame update
    void Start() {
        gameManager = GameManager.Instance;
        anim = gameObject.GetComponent<Animator>();
        UM = GameObject.Find("UiManager").GetComponent<UiManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Kill();
        }
    }

    void Kill()
    {
        if (_canKill && npc._isAlive)
        {
            gameManager.AddCorpse(npc.GetCorpseType());
            npc.Die();
            anim.SetTrigger("isKilling");
            GameManager.Instance.PlayerMadeFirstKill();
            SoundManager.Instance.PlayKillSound();
        }
        else
        {
            Debug.Log("cannot kill");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("NPC"))
        {
            npc = col.gameObject.GetComponent<npcLogic>();
            _canKill = true;
            if (!firstInteract) {
                UM.CreateDialogue("Now...\nkill them.");
                firstInteract = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            _canKill = false;
        }
    }
}
