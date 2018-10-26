using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float speedH = 10f;
    public float JumpForce = 10f;
    private Rigidbody2D rb2d;
    private bool isJumping;

    // Use this for initialization
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement for Horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(speedH * moveHorizontal, rb2d.velocity.y);

        Jump();
        //Debug.Log(isJumping);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb2d.AddForce(new Vector2(rb2d.velocity.x, JumpForce));
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            rb2d.velocity = Vector2.zero;
        }
    }
}