using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rigidbody2d;
    public float upForce = 200f;
    public bool isOnGround = false;
    public bool doubleJumpUsed = false;
    public bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rigidbody2d.AddForce(new Vector2(0, upForce));
            isOnGround = false;
            doubleJumpUsed = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !doubleJumpUsed)
        {
            doubleJumpUsed = true;
            rigidbody2d.AddForce(new Vector2(0, upForce));
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2d.AddForce(new Vector2(speed, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.AddForce(new Vector2(-speed, 0));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnGround = true;
        }
    }
}
 