﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMovement : MonoBehaviour
{

    public int player;
    public float xAxis;
    //public float yAxis;
    public float jumpAxis;
    Rigidbody2D rb;
    public float xSpeed;
    public float jumpForce;
    public int baseNbJumps;
    public int nbJumps;
    Animator animator;

    public bool grounded;


    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //jumping
        if (Input.GetButtonDown("JumpKeyboard" + player) || Input.GetButtonDown("JumpController" + player))
        {

            Jump();

        }

        //set grounded for animator
        animator.SetBool("Grounded", grounded);

        //special ability
        if (Input.GetButtonDown("Special" + player))
        {

            SpecialAbility();

        }

        //flip sprite when looking left
        if (xAxis < 0)
        {

            GetComponent<SpriteRenderer>().flipX = true;

        } else if (xAxis > 0)
        {

            GetComponent<SpriteRenderer>().flipX = false;


        }

    }

    private void FixedUpdate()
    {
        Debug.Log(Input.GetAxisRaw("HorizontalController" + player));
        //get the axis for the controller
        xAxis = Input.GetAxisRaw("HorizontalKeyboard" + player);
        //yAxis = Input.GetAxisRaw("Vertical" + player);

        if (xAxis == 0) {
            xAxis = Input.GetAxisRaw("HorizontalController" + player);
        }

        //set variables for animation
        animator.SetFloat("xAxis", xAxis);

        //set velocity for horizontal movement
        rb.velocity = new Vector3(xAxis * xSpeed, rb.velocity.y);


    }

    private void Jump ()
    {
        if (grounded || nbJumps > 0)
        {

            //set la velocity a 0
            rb.velocity = new Vector2(rb.velocity.x, 0);
            switch (nbJumps)
            {

                case 1:
                    //double jump
                    rb.AddForce(new Vector2(0, (jumpForce/1.5f)));


                    break;
                case 2:

                    //premier jump
                    rb.AddForce(new Vector2(0, jumpForce));


                    break;




            }
            nbJumps--;

        }
        grounded = false;

    }

    public void SpecialAbility ()
    {

        Debug.Log("Activatu supechialu ability!");

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag.Equals("Platform"))
        {

            grounded = true;
            nbJumps = baseNbJumps;


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag.Equals("Platform"))
        {

            grounded = false;

        }

    }


}
