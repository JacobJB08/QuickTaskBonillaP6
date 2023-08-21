using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float upForce = 200f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = Vector2.zero;
            rigidbody2d.AddForce(new Vector2(0, upForce));
        }
    }
}
