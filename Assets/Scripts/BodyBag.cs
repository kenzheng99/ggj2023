using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBag : MonoBehaviour
{
    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUpBodyBag();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playerInRange = false;
        }
    }
    void PickUpBodyBag()
    {
        Destroy(gameObject);
    }
}
