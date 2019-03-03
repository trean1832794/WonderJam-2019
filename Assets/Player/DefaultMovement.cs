using UnityEngine;

public class DefaultMovement : MonoBehaviour {

    public int player;
    private float xAxis;
    //public float yAxis;
    private float jumpAxis;
    Rigidbody2D rb;
    public float xSpeed;
    public float jumpForce;
    public int baseNbJumps;
    public int nbJumps;
    Animator animator;
    public bool canMove = true;

    public AudioClip player1Jump;
    public AudioClip player2Jump;
    public AudioClip groundSound;

    private bool grounded;


    private void Awake() {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        //movement
        if (canMove) {
            //jumping
            if (Input.GetButtonDown("JumpKeyboard" + player) || Input.GetButtonDown("JumpController" + player)) {

                Jump();

            }

            //set grounded for animator
            animator.SetBool("Grounded", grounded);

            //special ability
            if (Input.GetButtonDown("Special" + player)) {

                SpecialAbility();

            }

            //flip sprite when looking left
            if (xAxis < 0) {

                GetComponent<SpriteRenderer>().flipX = true;

            } else if (xAxis > 0) {

                GetComponent<SpriteRenderer>().flipX = false;


            }

        }

    }

    private void FixedUpdate() {
        if (canMove) {

            //get the axis for the controller
            xAxis = Input.GetAxisRaw("HorizontalKeyboard" + player);
            //yAxis = Input.GetAxisRaw("Vertical" + player);

            if (xAxis == 0) {
                xAxis = Input.GetAxisRaw("HorizontalController" + player);
            }

            //set variables for animation
            animator.SetFloat("xAxis", xAxis);  

            //set velocity for horizontal movemen

            rb.velocity = new Vector3(xAxis * xSpeed, rb.velocity.y);

        }

    }

    private void Jump() {
        if (grounded || nbJumps > 0) {

            //set la velocity a 0
            rb.velocity = new Vector2(rb.velocity.x, 0);
            if (nbJumps == baseNbJumps) {
                //premier jump
                rb.AddForce(new Vector2(0, jumpForce));


            } else {

                //double jump
                rb.AddForce(new Vector2(0, (jumpForce / 1.25f)));

            }

            nbJumps--;
            if (player == 1)
            {

                GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(player1Jump);

            } else
            {

                GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(player2Jump);

            }

        }
        grounded = false;

    }

    public void SpecialAbility() {

        Debug.Log("Activatu supechialu ability!");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (!canMove && collision.gameObject.tag == "Wall")
        {

            canMove = true;

        }

    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag.Equals("Platform")) {
            if (!collision.GetComponent<BoxCollider2D>().isTrigger) {
                if (!grounded)
                {
                    GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(groundSound);
                }
                grounded = true;
                nbJumps = baseNbJumps;
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {

        if (collision.tag.Equals("Platform")) {

            grounded = false;

        }

    }


}
