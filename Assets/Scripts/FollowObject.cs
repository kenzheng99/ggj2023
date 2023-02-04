using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {
    [SerializeField] private GameObject objectToFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        Vector3 targetPosition = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
        transform.position = targetPosition;
    }
}
