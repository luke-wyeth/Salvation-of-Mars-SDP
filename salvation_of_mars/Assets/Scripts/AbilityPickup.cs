using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    private SpringJoint2D abilitySpring;

    // Start is called before the first frame update
    //object does not connect becuase it is false at the start
    //Recieve a gameobject with a tag "Backpack"
    void Start()
    {
        abilitySpring = GetComponent<SpringJoint2D>();
        abilitySpring.enabled = false;
        GameObject BackPack2 = GameObject.FindWithTag("Backpack2");
        abilitySpring.connectedBody = BackPack2.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //Object should connect when a gameobject with a tag "Player" collides with it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInfo pi = collision.gameObject.GetComponent<PlayerInfo>();

        if (collision.gameObject.tag == "Player" && !abilitySpring.enabled)
        {
            abilitySpring.enabled = true;
            //pi.abilityUnlock = true; // causing problemns right now
        }
    }
}

