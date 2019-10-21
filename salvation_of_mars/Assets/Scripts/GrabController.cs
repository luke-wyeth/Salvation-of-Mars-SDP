using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f; //Max distance we can detect something
    public Transform holdPoint;
    public float throwForce = 10f; //5f
    private float weakThrowTime = 2.0f, StrongThrowTime = 5.0f;
    private float throwChargeTimer = 0f;
    private GameObject grabbedObject;
    //public LayerMask notGrabbed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Grab"))
        {
            if (!grabbed) //then grab
            {
                projectRaycastFromPlayerMidline();
                checkIfPlayerInRangeOfGrabbable();
            }
            else //Drop object logic
            {
                //else if (!Physics2D.OverlapPoint(holdPoint.position)) //throw
                grabbed = false;
                fixDroppedObjectFallingRate();
            }

            throwChargeTimer += Time.deltaTime;
        }
        else if (Input.GetButtonDown("Grab")) // else if branch for throw eligibility
        {
            throwChargeTimer += Time.deltaTime;
            if (grabbed && (throwChargeTimer > weakThrowTime))
            {
                grabbed = false;

                throwObjectUpwards();
                resetThrowChargeTimer();
            } 
        }

        if (grabbed) 
        {
            //Change the objects location to that of the holding point above the player
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
    }

    /// <summary>
    /// Visual representation of raycast only used for development purposes
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 raycastOrigin = transform.position;
        raycastOrigin.y += 0.5f;
        Gizmos.DrawLine(raycastOrigin, raycastOrigin + Vector2.right * transform.localScale.x * distance);
    }

    /// <summary>
    /// Generate a raycast to see if the player collides with a grabbable object
    /// </summary>
    private void projectRaycastFromPlayerMidline()
    {
        Physics2D.queriesStartInColliders = false; //Ignore player's own collider                                      
        Vector2 raycastOrigin = transform.position;
        raycastOrigin.y += 0.1f;
        hit = Physics2D.Raycast(raycastOrigin, Vector2.right * transform.localScale.x, distance);
    }

    /// <summary>
    /// If a player is close enough to a grabbable
    /// object then allow that object to be grabbed
    /// </summary>
    private void checkIfPlayerInRangeOfGrabbable()
    {
        if (hit.collider != null && hit.collider.tag == "Grabbable")
        {
            grabbed = true;
            grabbedObject = hit.collider.gameObject;
        }
    }

    /// <summary>
    /// Logic for throwing a held object at a roughly 45 degree angle away
    /// from where the player is facing
    /// </summary>
    private void throwObjectUpwards()
    {
        if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwForce;

        }
    }

    /// <summary>
    /// When the player has thrown the object we need
    /// to reset the timer so we can resume incrementing the time duration of 
    /// the throw charge
    /// </summary>
    private void resetThrowChargeTimer()
    {
        throwChargeTimer = 0f;
    }
    
    /// <summary>
    /// After an object is picked up, and the player wants to drop it
    /// the object accelerates towards the ground and why this is happening is not
    /// clear, however this method fixes the dropped object by only moving it 0.0000f y units in the down direction
    /// </summary>
    private void fixDroppedObjectFallingRate()
    {
        if (grabbedObject != null)
        {
            grabbedObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -0.0001f, 0);
        }    
    }

    /// <summary>
    /// For development purposes, not used in end game production
    /// </summary>
    private void projectRaycastFromPlayerHeadline()
    {
        Physics2D.queriesStartInColliders = false; //Ignore player's own collider                                      
        Vector2 raycastOrigin = transform.position;
        raycastOrigin.y += 0.5f;
        hit = Physics2D.Raycast(raycastOrigin, Vector2.right * transform.localScale.x, distance);
    }
}

