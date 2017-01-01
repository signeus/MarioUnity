using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
         player = gameObject.GetComponentInParent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        TakeGround(true);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        TakeGround(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        TakeGround(true);
    }

    void TakeGround(bool action)
    {
        player.grounded = action;
    }
}
