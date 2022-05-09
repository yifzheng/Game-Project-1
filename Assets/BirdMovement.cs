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
    [SerializeField] float jumpForce = 1500.0f;  // variable to store jump force
    [SerializeField] Text healthTxt; // the text object displaying the health of the bird
    public GameObject Panel; // gameover panel
    public GameObject InstructionsPanel; // instructions panel
    [SerializeField] GameObject scoreKeeper;
    int health; // the initial health of the bird 
    const int scoreForLEvel = 100; // the maximum score for this level
    bool instruction = false; // boolean to pause game and open instruction panel
    // Start is called before the first frame update
    void Start()
    {
        if(rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        if (scoreKeeper == null)
        {
            scoreKeeper = GameObject.FindGameObjectWithTag("ScoreKeeper");
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
    // trigger collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Finish")
        {
            int finalScore = scoreForLEvel * (health / 100); // score for level is 100 * the percentage of health / 100
            scoreKeeper.GetComponent<ScoreKeeper>().UpdateScore(finalScore);
            SceneManager.LoadScene("Part1Facts");
        }
        if (collider.gameObject.tag == "Smog")
        {
            LowerHealth();
        }
    }

    // actual collider
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Platform")
        {
            ToggleInstructionPanel();
        }
    }

    void DisplayHealth()
    {
        healthTxt.text = "Health: " + health;
    }

    // function to decrease health of the bird
    void LowerHealth()
    {
        health -= 10;
        DisplayHealth();
        // if the health is <= 0, relaod scene and reset hp and score if available
        if (health <= 0)
        {
            // if health is 0, toggle panel and show gameover panel
            TogglePanel();
            // pause game
            Time.timeScale = 0.0f;
        }
    }
    // toggle panel function
    public void TogglePanel()
    {
        Panel.SetActive(true);
    }
    // function to tooggle the instructions panel
    public void ToggleInstructionPanel()
    {
        if (InstructionsPanel != null)
        {
            bool isActive = InstructionsPanel.activeSelf; // boolean to store active value
            instruction = !instruction; // negate the value of instruction
            if (instruction == true) 
            {
                // if instruction is true, pause game
                Time.timeScale = 0.0f;
            }
            else
            {
                // else resume game
                Time.timeScale = 1.0f;
            }
            InstructionsPanel.SetActive(!isActive); // toggle panel
        }
    }
}
