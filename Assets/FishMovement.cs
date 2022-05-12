using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

	
    [SerializeField] float movement, movement2;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        if(rb==null)
       		rb= GetComponent<Rigidbody2D>();
        speed=15;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
       	movement2 = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    { 
    	rb.velocity = new Vector2(movement2 * speed, rb.velocity.y);
    	rb.velocity = new Vector2(movement * speed, rb.velocity.x);
        if (movement > 0 && isFacingRight || movement < 0 && !isFacingRight)
            Flip();        
        
    }
   
    
      void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}
