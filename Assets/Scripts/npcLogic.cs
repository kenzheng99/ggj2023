using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcLogic : MonoBehaviour
{
    private bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void die()
    {
        if (isAlive)
        {
            Debug.Log("dead NPC");
            Vector3 fallRotation = new Vector3(0, 0, 90);
            transform.Rotate(fallRotation);
            isAlive = false;
        }
        
    }
}
