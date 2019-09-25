using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    public GameObject player;
    public GameObject clone;
    private PlayerMovement playerControl;
    private PlayerMovement cloneControl;
    private bool cloneVisible;

    private Rigidbody2D cBody; // clone body
    private Rigidbody2D pBody; // player body

    public bool cFrozen; // clone frozen status
    public bool pFrozen; // player frozen status

    // Start is called before the first frame update
    void Start()
    {
        cFrozen = true; // clone starts off frozen, hasn't been activated yet
        pFrozen = false;

        if(player == null || clone == null)
        {
            player = GameObject.Find("Player"); // assign player object
            clone = GameObject.Find("Clone"); // assign clone object
        }
        
        playerControl = player.GetComponent<PlayerMovement>(); // get the playerMovement script to enable and disable as necessary
        
        cloneControl = clone.GetComponent<PlayerMovement>();

        pBody = player.GetComponent<Rigidbody2D>();
        cBody = clone.GetComponent<Rigidbody2D>();

        cloneVisible = false; // set current state of clone

        clone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if ability3 triggered (clone)
        if (Input.GetButtonDown("Fire3")&& SkillSelect.cloneSelected)
        {
            cloneAbilityButtonPressed();
        }
    }

    private void FixedUpdate()
    {
        if (cFrozen) // if clone should be frozen, freeze them
        {
            cBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            pBody.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        }
        if (pFrozen) // if player should be frozen, freeze them
        {
            pBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            cBody.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        }
    }

    public void cloneAbilityButtonPressed()
    {
        // if clone has not been created yet, create a clone and switch control to the clone
        if (!cloneVisible)
        {
            cloneVisible = true;

            clone.SetActive(true); // enable clone object + sprite

            clone.transform.position = player.transform.position; // teleport clone to same spot as player

            cFrozen = false;
            pFrozen = true;
            //pBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            playerControl.enabled = false; // disable control of the player
            cloneControl.enabled = true; // enable control of the clone

        }
        // if clone is already created, switch control to opposite (e.g switch from clone to player or vice versa)
        else if (cloneVisible)
        {
            // flip which character is frozen
            pFrozen = !pFrozen;
            cFrozen = !cFrozen;

            // flip which character control is enabled
            playerControl.enabled = !playerControl.enabled;
            cloneControl.enabled = !cloneControl.enabled;
        }

    }
}

