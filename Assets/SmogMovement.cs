using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed = 3;
    [SerializeField] int yMax = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.position.y >= yMax)
        {
            Destroy(gameObject);
        }
        moveUp(speed);
    }

    void moveUp(int speed)
    {
        rigid.MovePosition(rigid.position + (new Vector2(0,speed)) * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
