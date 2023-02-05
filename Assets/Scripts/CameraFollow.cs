using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour {
    [SerializeField] private GameObject objectToFollow;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    
    void Update() {
        float x = objectToFollow.transform.position.x;
        float y = objectToFollow.transform.position.y;
        if (x < minX) {
            x = minX;
        }
        if (x > maxX) {
            x = maxX;
        }

        if (y < minY) {
            y = minY;
        }
        if (y > maxY) {
            y = maxY;
        }
        
        Vector3 targetPosition = new Vector3(x, y, transform.position.z);
        transform.position = targetPosition;
    }
}
