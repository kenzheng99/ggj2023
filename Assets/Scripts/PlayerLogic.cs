using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private bool _canKill;
    public npcLogic npc;
    private GameManager gameManager;

    // private Collision2D NPC;
    
    // Start is called before the first frame update
    void Start() {
        gameManager = GameManager.Instance;
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
        if (_canKill)
        {
            // TODO make this type dynamic
            gameManager.AddCorpse(CorpseType.TYPE1);
            npc.Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("NPC"))
        {
            npc = col.gameObject.GetComponent<npcLogic>();
            _canKill = true;
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
