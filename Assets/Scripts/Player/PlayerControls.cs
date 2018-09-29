using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float speedH = 4f;
    private float speedV = 8f;
    public float maxSpeed;
    private Rigidbody2D rb2d;
    private bool onGround = false;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = speedH * Input.GetAxis("Horizontal");

        float moveVertical = speedV *  Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speedH);


    }

    /*
    void OnCollisionEnter2D(Collision2D coll)
    {

    }
    */
}
