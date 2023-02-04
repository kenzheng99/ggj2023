using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicYSort : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y > player.transform.position.y)
        {
            this.gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("DynamicBack");
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("DynamicFront");
        }
    }
}
