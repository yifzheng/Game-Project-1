using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

  [SerializeField] Rigidbody2D rb;

  [SerializeField] bool isFacingRight = true;
  public float speed;
  private Transform target;
  Vector3 location;
    // Start is called before the first frame update
    void Start()
    {
      if(rb==null)
        rb= GetComponent<Rigidbody2D>();
      speed=5;
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position,target.position,1*speed*Time.deltaTime);

    }
    void FixedUpdate()
    {



        

    }


      void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}
