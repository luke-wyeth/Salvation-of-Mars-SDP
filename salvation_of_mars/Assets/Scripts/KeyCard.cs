using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    private SpringJoint2D spring;
    // Start is called before the first frame update
    //object does not connect becuase it is false at the start
    //Reciece a gameobject with a tag "Backpack"
    void Start()
    {
        spring = GetComponent<SpringJoint2D>();
        spring.enabled = false;
        GameObject backpack = GameObject.FindWithTag("Backpack");
        spring.connectedBody = backpack.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //Object should connect when a gameobject with a tag "Player" collides with it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !spring.enabled)
        { 
            spring.enabled = true;
            PlayerInfo pi = collision.gameObject.GetComponent<PlayerInfo>();
            pi.collectedCard = true;
        }
    }
}