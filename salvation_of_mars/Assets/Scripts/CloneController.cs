using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    public GameObject player; // player object
    public GameObject clone; // clone object
    private PlayerMovement playerControl;
    private PlayerMovement cloneControl;
    private bool cloneVisible; // is the clone visible?

    private Rigidbody2D cBody; // clone body
    private Rigidbody2D pBody; // player body

    public bool cFrozen; // clone frozen status
    public bool pFrozen; // player frozen status

    public GameObject playerArrow; // arrow indicator icon over head of player
    public GameObject cloneArrow; // arrow indicator over clone

    // Start is called before the first frame update
    void Start()
    {
        cFrozen = true; // clone starts off frozen, hasn't been activated yet
        pFrozen = false;

        if(player == null || clone == null) // if player and clone objects not assigned, find them
        {
            player = GameObject.Find("Player"); // assign player object
            clone = GameObject.Find("Clone"); // assign clone object
        }
        
        playerControl = player.GetComponent<PlayerMovement>(); // get the playerMovement script to enable and disable as necessary
        
        cloneControl = clone.GetComponent<PlayerMovement>();

        pBody = player.GetComponent<Rigidbody2D>(); // get rigidbody component from player object
        cBody = clone.GetComponent<Rigidbody2D>();

        // get player and clone arrows automatically - easier than manually having to add in each scene
        playerArrow = GameObject.Find("pArrow");
        cloneArrow = GameObject.Find("cArrow");

        cloneVisible = false; // set current state of clone

        clone.SetActive(false); // clone not spawned in scene yet

        playerArrow.SetActive(false); // neither arrow should be active since clone is not spawned yet
        cloneArrow.SetActive(false);
    }

    // Update is automatically called once per frame
    void Update()
    {
        // if ability3 triggered (clone)
        if (Input.GetButtonDown("Fire3")&& SkillSelect.cloneSelected&& !SkillSelect.isActive)
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

            playerControl.enabled = false; // disable control of the player
            cloneControl.enabled = true; // enable control of the clone

            cloneArrow.SetActive(true);
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

            // flip which arrow is enabled
            cloneArrow.SetActive(!cloneArrow.activeSelf);
            playerArrow.SetActive(!playerArrow.activeSelf);
        }

    }

    public PlayerMovement getCloneControl()
    {
        return cloneControl;
    }
}

