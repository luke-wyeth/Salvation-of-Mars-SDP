using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleText : MonoBehaviour
{
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>(); // get the sprite renderer of the object this is attached to
        sr.enabled = false; // disable rendering - make the object invisible but still active
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sr.enabled = true; // enable rendering - visible and active
    }

}
