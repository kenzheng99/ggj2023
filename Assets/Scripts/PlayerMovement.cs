using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 movementVector = new Vector3(inputX, inputY, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movementVector);

    }
}
