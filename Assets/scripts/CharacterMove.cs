using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

    public float maxSpeed = 10f;
    
    //AXIS
    bool right = false;
    bool left = false;
    bool up = false;
    bool down = false;

	// Use this for initialization
	void Start () {
	    //TODO Get Animator component when is created
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        //TODO Animation with the speed and direction

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

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
