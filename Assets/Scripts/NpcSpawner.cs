using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    public GameObject npcPrefab1;
    public GameObject npcPrefab2;
    public GameObject npcPrefab3;

    [SerializeField] private int min;
    [SerializeField] private int max;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNpc(MapSize.w, MapSize.h);
    }

    private void SpawnNpc(float w, float h)
    {
        // forest has width 38 height 23
        for (int i = 0; i < Random.Range(min,max); i++) {
            int rand = Random.Range(0, 3);
            GameObject npcToSpawn;
            if (rand == 0) {
                npcToSpawn = npcPrefab1;
            } else if (rand == 1) {
                npcToSpawn = npcPrefab2;
            } else {
                npcToSpawn = npcPrefab3;
            }
            
            GameObject npcObject = Instantiate(npcToSpawn, new Vector3(Random.Range(-w, w), Random.Range(-h, h), 0), transform.rotation);
            CorpseType randomType = DataUtils.IndexToCorpseType(rand);
            npcObject.GetComponent<npcLogic>().SetCorpseType(randomType);
        }
    }
    // Update is called once per frame
}
