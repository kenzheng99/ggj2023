using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private bool _canKill;
    public npcLogic npc;
    private GameManager gameManager;
    Animator anim;

    // private Collision2D NPC;
    
    // Start is called before the first frame update
    void Start() {
        gameManager = GameManager.Instance;
        anim = gameObject.GetComponent<Animator>();
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
            if (npc._isAlive == true)
            {
                _canKill = true;
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
