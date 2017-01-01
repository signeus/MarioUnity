using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 50f;

    public bool grounded;
    public bool jumping = false;

    private Rigidbody2D rigidBody2D;

    private Animator animator;

    private float jumpingTime = 0.0f;
    private float realJump = 0.0f;

	// Use this for initialization
	void Start () {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        animator.SetBool("Grounded", grounded);
        animator.SetBool("Jumping", jumping);
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxis("Horizontal") < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetAxis("Horizontal") > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);

        if (((Input.GetAxis("Jump") > 0.1f) && grounded) && !jumping) { 
            jumping = true;
            grounded = false;
        }

        if (Input.GetAxis("Jump") <= 0.0)
            jumping = false;
        /*
        if ((Input.GetAxis("Jump") > 0.1f) && grounded)
        {
            Vector2 force = Vector2.up * jumpPower;
            rigidBody2D.AddForce(force);
            float forceJump = force.y;
            grounded = false;
        }
        */
    }
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        //Moving the player
        rigidBody2D.AddForce((Vector2.right * speed) * horizontal);

        //Limiting the speed of the player
        if(rigidBody2D.velocity.x > maxSpeed)
        {
            rigidBody2D.velocity = new Vector2(maxSpeed, rigidBody2D.velocity.y);
        }

        if (rigidBody2D.velocity.x < -maxSpeed)
        {
            rigidBody2D.velocity = new Vector2(-maxSpeed, rigidBody2D.velocity.y);
        }

        //Limiting the jump of the player
        if ((Input.GetAxis("Jump") > 0.1f) && jumping)
        {
            jumpingTime = jumpingTime + 1f;
            realJump = jumpingTime * jumpPower;
            Vector2 force = Vector2.up * realJump;
            rigidBody2D.AddForce(force);
            if (jumpingTime > 5f)
            {
                jumpingTime = 0.0f;
                jumping = false;
            }
        }
    }
}
