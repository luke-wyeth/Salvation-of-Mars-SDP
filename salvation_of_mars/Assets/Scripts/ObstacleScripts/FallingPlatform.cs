using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();  // load rigidbody of object this is attached to
    }


    private void OnCollisionEnter2D(Collision2D collision) // on ENTERING platform (jump on, walk on)
    {
        body.bodyType = RigidbodyType2D.Dynamic; // make platform affected by gravity
    }
}
