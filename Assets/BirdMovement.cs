using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] float movement; // variable to store sprite movement
    [SerializeField] bool isFacingRight = true; // check if sprite is facing right
    [SerializeField] Rigidbody2D rigid; // rigid body
    [SerializeField] bool jumpPressed = false; // check if jump is pressed
    [SerializeField] float jumpForce = 1000.0f;  // variable to store jump force
    [SerializeField] Text healthTxt; // the text object displaying the health of the bird
    public GameObject Panel;
    int health; // the initial health of the bird 

    // Start is called before the first frame update
    void Start()
    {
        if(rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        health = 100;
        DisplayHealth();
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Part2");
        }
        if (collider.gameObject.tag == "Smog")
        {
            LowerHealth();
        }
    }

    void DisplayHealth()
    {
        healthTxt.text = "Health:" + health;
    }

    // function to decrease health of the bird
    void LowerHealth()
    {
        health -= 10;
        // if the health is <= 0, relaod scene and reset hp and score if available
        if (health <= 0)
        {
            // if health is 0, toggle panel and show gameover panel
            TogglePanel();
            // pause game
            Time.timeScale = 0.0f;
        }
        else
        {
            DisplayHealth();
        }
    }
    // toggle panel function
    public void TogglePanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}
