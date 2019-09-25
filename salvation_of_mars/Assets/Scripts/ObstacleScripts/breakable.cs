using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionExit2D(Collision2D collision) // when LEAVING the section
    {
        body.bodyType = RigidbodyType2D.Dynamic; // make body affected by gravity
    }
}
