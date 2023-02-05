using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 2;
    public Rigidbody2D rb;
    public Animator anim;
    private Vector2 moveDirection;
    private GameManager gameManager;

    void Start() {
        gameManager = GameManager.Instance;
        transform.position = gameManager.GetPlayerSpawnPosition();
    }
    void Update()
    {
        ProcessInputs();
        Animate();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * playerSpeed, moveDirection.y * playerSpeed);
    }

    void Animate()
    {
        anim.SetFloat("moveX", moveDirection.x);
        anim.SetFloat("moveY", moveDirection.y);
    }
}

