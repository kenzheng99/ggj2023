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
        SpawnNpc(MapSize.w, MapSize.h);
    }

    private void SpawnNpc(float w, float h)
    {
        // forest has width 38 height 23
        for (int i = 0; i < Random.Range(3,6); i++)
        {
            GameObject npcObject = Instantiate(npc, new Vector3(Random.Range(-w, w), Random.Range(-h, h), 0), transform.rotation);
            CorpseType randomType = DataUtils.IndexToCorpseType(Random.Range(0, 3));
            npcObject.GetComponent<npcLogic>().SetCorpseType(randomType);
        }
    }
    // Update is called once per frame
}
