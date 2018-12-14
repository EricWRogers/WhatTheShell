using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{

    public float speedH = 10f;
    public float JumpForce = 10f;
    private Rigidbody2D rb2d;
    public bool isJumping;
    public int Health = 3;


    public bool IsGrounded;
    private float speedForce = 0f;
    private float minAirTime = .5f;
    private float maxAirTime = 2f;
    public float maxJumpHeight;
    public float minJumpHeight;
    public Transform GroundCheckOrigin;
    public Transform detectEnemyOrigin;
    


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

        // Jump();
        //Debug.Log(isJumping);
        RaycastHit2D hit = Physics2D.Raycast(GroundCheckOrigin.position, transform.up * -1, .05f);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Ground")
            {
                // Debug.Log("Hit!");
                IsGrounded = true;
               // a2d.SetBool("IsGrounded", true);
            }

            if(hit.collider.tag == "Enemy")
            {
                Destroy(hit.transform.gameObject);
            }

        }

        if (Input.GetKey(KeyCode.Space) && IsGrounded == true)
        {
            if (speedForce <= maxAirTime)
            {
                speedForce += .2f;
            }

            else
            {
                Jump();
            }

        }

        if (Input.GetKeyUp(KeyCode.Space) && IsGrounded == true)
        {
            Jump();
        }

    
    }

    //Makes the Player Jump if it is on ground
    void Jump()
    {
        if (speedForce < minAirTime)
        {
            rb2d.AddForce(new Vector2(0, minJumpHeight * minAirTime), ForceMode2D.Impulse);
        }

        else if (speedForce > maxAirTime)
        {
            rb2d.AddForce(new Vector2(0, maxJumpHeight * maxAirTime), ForceMode2D.Impulse);
        }

        else
        {
            rb2d.AddForce(new Vector2(0, minJumpHeight * minAirTime), ForceMode2D.Impulse);
        }
        //jump animation bool stuff
       // a2d.SetBool("IsGrounded", false);
        IsGrounded = false;
        speedForce = 0f;
    }

    //Checks collisions
    void OnCollisionEnter2D(Collision2D other)
    {
        //Checks ground Collision
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            //rb2d.velocity = Vector2.zero;
        }

        //Manipulates Health if Player hits enemy and calls game over
        if (other.gameObject.CompareTag("Enemy"))
        { 
            Health--;
            //Debug.Log(Health);
            Vector2 newVeloc = rb2d.velocity;
            newVeloc.x *= -1;
            rb2d.velocity = newVeloc;

            if(Health < 0)
            {
                //add in game over scene
            }
        }

        if(other.gameObject.tag == "BurnMotherFucker")
        {
            SceneManager.LoadScene(0);
        }
    }
}
