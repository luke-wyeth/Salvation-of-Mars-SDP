using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject connectedObject;
    public GameObject player;
    public bool teleported;

    // Start is called before the first frame update
    //find if player is next to an object
    void Start()
    {
        teleported = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    //unable to teleport if wrong input
    void Update()
    {
        if(teleported && Input.GetAxisRaw("Vertical") < 1)
        {
            teleported = false;
        }
    }

    //if player is next to an object with collision and user inputs W then teleport to the connected object
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Input.GetAxisRaw("Vertical") == 1 && !teleported)
            {
                player.transform.position = connectedObject.transform.position;
                connectedObject.GetComponent<Teleport>().teleported = true;
                teleport();
            }
        }
    }

    public void teleport()
    {
        teleported = true;
    }
}
