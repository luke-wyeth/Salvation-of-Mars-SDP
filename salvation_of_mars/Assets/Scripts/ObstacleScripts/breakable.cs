using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    private Rigidbody2D body;
    private float jumpedOn;
    private bool touched;
    public float lengthAllowedOn;

    // Start is called before the first frame update
    void Start() 
    {
        body = gameObject.GetComponent<Rigidbody2D>(); // load rigidbody of the platform this is attached to
<<<<<<< HEAD

        if(lengthAllowedOn <= 0)
        {
            lengthAllowedOn = 2f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // when player jumps on the platform
    {
        jumpedOn = Time.time; // record the time the player first touched
        touched = true; 
    }

    private void Update()
    {
        if(touched && (Time.time - lengthAllowedOn) > jumpedOn) // if 1 second has passed since player first touched
        {
            Debug.Log("timeup");
            fallDown();
        }
=======
>>>>>>> parent of e4ce24d... Merge branch 'master' of https://github.com/luke-wyeth/Salvation-of-mars-sprint2
    }

    private void OnCollisionExit2D(Collision2D collision) // when LEAVING the section
    {
<<<<<<< HEAD
        Debug.Log("exited");
        fallDown();
    }

    private void fallDown()
    {
=======
>>>>>>> parent of e4ce24d... Merge branch 'master' of https://github.com/luke-wyeth/Salvation-of-mars-sprint2
        body.bodyType = RigidbodyType2D.Dynamic; // make body affected by gravity
    }
}
