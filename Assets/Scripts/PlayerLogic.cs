using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private bool canKill;
    public npcLogic npc;

    // private Collision2D NPC;
    private GameObject NPC;
    
    // Start is called before the first frame update
    void Start()
    {
        npc = GameObject.FindWithTag("NPC").GetComponent<npcLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            kill();
        }
    }

    void kill()
    {
        if (canKill)
        {
            Debug.Log("KILL");
            npc.die();
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
            canKill = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            canKill = false;
        }
    }
}
