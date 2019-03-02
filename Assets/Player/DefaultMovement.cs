using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMovement : MonoBehaviour
{

    public int player;
    public float xAxis;
    public float yAxis;
    public float jumpAxis;
    Rigidbody2D rb;
    public float xSpeed;
    public float jumpForce;
    public int baseNbJumps;
    public int nbJumps;

    public bool grounded;


    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //jumping
        if (Input.GetButtonDown("Jump" + player))
        {

            Jump();

        }

        //special ability
        if (Input.GetButtonDown("Special" + player))
        {

            SpecialAbility();

        }

    }

    private void FixedUpdate()
    {

        //get the axis for the controller
        xAxis = Input.GetAxisRaw("Horizontal" + player);
        yAxis = Input.GetAxisRaw("Vertical" + player);

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

    private void OnTriggerEnter2D(Collider2D collision)
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
