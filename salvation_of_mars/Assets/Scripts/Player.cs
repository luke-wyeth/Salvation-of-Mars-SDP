using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower = 150f;
    public float runSpeed = 50f;
    public bool onGround;
    private Rigidbody2D body;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        body.AddForce(Vector2.right * runSpeed * hInput);
    }
}
