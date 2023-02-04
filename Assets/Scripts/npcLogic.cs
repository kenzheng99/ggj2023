using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class npcLogic : MonoBehaviour
{
    private bool _isAlive;
    private float _mapWidth;
    private float _mapHeight;
    
    private float _moveTimer;
    [SerializeField] private float waitTime = 5;
    private Vector3 _dir;

    private CorpseType type;

    // Start is called before the first frame update
    void Start()
    {
        _isAlive = true;
        _moveTimer = 5; // NPC move on start
        Debug.Log("NPC Created");
    }

    public void SetCorpseType(CorpseType corpseType) {
        type = corpseType;
    }

    public CorpseType GetCorpseType() {
        return type;
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveTimer > waitTime)
        {
            if (Random.Range(0, 4) > 1)
            {
                _dir = new Vector3(Random.Range(-MapSize.w, MapSize.w), Random.Range(-MapSize.h, MapSize.h), 0);
            }
            _moveTimer = 0;
            waitTime = Random.Range(3, 7);
        }
        else
        {
            _moveTimer += Time.deltaTime;
        }

        if (_isAlive)
        {
            if (Math.Abs(transform.position.x) > Math.Abs(MapSize.w)
                || Math.Abs(transform.position.y) > Math.Abs(MapSize.h))
            {
                _dir = new Vector3(-_dir.x, -_dir.y, 0);
            }
            transform.Translate((float)(.1) * Time.deltaTime * _dir);
        }
    }

    public void Die()
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
