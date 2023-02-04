using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    public GameObject npc;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawn shit");
        SpawnNpc(20, 10);
    }

    private void SpawnNpc(float w, float h)
    {
        // forest has width 38 height 23
        for (int i = 0; i < Random.Range(3,6); i++)
        {
            Instantiate(npc, new Vector3(Random.Range(-w, w), Random.Range(-h, h), 0), transform.rotation);
        }
    }
    // Update is called once per frame
}
