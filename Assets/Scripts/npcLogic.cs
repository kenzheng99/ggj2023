using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class npcLogic : MonoBehaviour
{
    private bool _isAlive;
    private float _mapWidth;
    private float _mapHeight;

    // Start is called before the first frame update
    void Start()
    {
        _isAlive = true;
        Debug.Log("NPC Created");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void die()
    {
        if (_isAlive)
        {
            Debug.Log("dead NPC");
            Vector3 fallRotation = new Vector3(0, 0, 90);
            transform.Rotate(fallRotation);
            _isAlive = false;
        }
        
    }
}
