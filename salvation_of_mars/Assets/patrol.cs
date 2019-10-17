using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    public float speed; // how fast the character will move.
    public float distance; // the distance character must cover.
    private bool moveRight = true; // this will be used to tell the character once the reaches the end of the platform, where it needs to move towards.
    public Transform groundDetection; // shoots a ray to detect ground collision.

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); // moves the character forward (towards right direction).

        RaycastHit2D grounder = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);  // creates a ray and shoots it downwards

        if (grounder.collider == false) // if rays hasn collied with anything
        {
            if (moveRight == true) // if character is moving right turns character in the opposite direction. 
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else  // if character is moving left turns character in the opposite direction. 
            {
                transform.eulerAngles = new Vector3(0, 0, 0); 
                moveRight = true;
            }
        }

    }

}
