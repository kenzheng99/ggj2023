using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    private GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawn shit");
        _gm = GameManager.Instance;
        _gm.SpawnNPC(20, 10);
    }

    // Update is called once per frame
}
