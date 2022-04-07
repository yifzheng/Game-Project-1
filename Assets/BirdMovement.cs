using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] float movement; // variable to store sprite movement
    [SerializeField] bool isFacingRight = true; // check if sprite is facing right
    [SerializeField] Rigidbody2D rigid; // rigid body
    [SerializeField] bool jumpPressed = false; // check if jump is pressed
    [SerializeField] float jumpForce = 1000.0f;  // variable to store jump force
    // Start is called before the first frame update
    void Start()
    {
        if(rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal"); // get movement horizontally
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement * 1, 0);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed)
            Jump();
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
    }

}
