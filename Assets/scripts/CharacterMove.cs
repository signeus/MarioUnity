using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

    public float maxSpeed = 10f;
    public float jump = 5f;



    //AXIS
    bool right = false;
    bool left = false;
    bool up = false;
    bool down = false;

    bool isGround = true;

	// Use this for initialization
	void Start () {
	    //TODO Get Animator component when is created
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float jumpForce = Input.GetAxis("Jump");

        float realJump = 0;

        if (jumpForce > 0 && isGround)
        {
            realJump = jump * jumpForce;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, realJump);
            if (realJump >= 10f)
            {
                isGround = false;
            }
        }

        float move = Input.GetAxis("Horizontal");
        //TODO Animation with the speed and direction
        if (move > 0 || move < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if(move > 0 && !right)
        {
            Flip();
        }
        else
        {
            if(move < 0 && right)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        right = !right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
