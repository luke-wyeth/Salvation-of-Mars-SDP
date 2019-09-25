using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f; //Max distance we can detect something
    public Transform holdPoint;
    public float throwForce = 10; //5f
    private float weakThrowTime = 2.0f, StrongThrowTime = 5.0f;
    private float throwChargeTimer = 0f;
    //public LayerMask notGrabbed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!grabbed) //then grab
            {
                projectRaycastFromPlayerMidline();
                checkIfPlayerInRangeOfGrabbable();
            }
            else //throw
            {
                //else if (!Physics2D.OverlapPoint(holdPoint.position)) //throw
                grabbed = false;
                //throwChargeTimer = 0f;
                //throwObjectUpwards();
            }


        }
        else if (Input.GetKey(KeyCode.V))
        {
            throwChargeTimer += Time.deltaTime;
            if (grabbed && throwChargeTimer > weakThrowTime)
            {
                grabbed = false;

                throwObjectUpwards();
                throwChargeTimer = 0f;
            }
        }


        if (grabbed)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
    }

    /// <summary>
    /// Visual representation of raycast
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 raycastOrigin = transform.position;
        raycastOrigin.y += 0.1f;
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

    private void checkIfPlayerInRangeOfGrabbable()
    {
        if (hit.collider != null && hit.collider.tag == "Grabbable")
        {
            grabbed = true;
        }
    }

    private void throwObjectUpwards()
    {
        if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwForce;

        }
    }
}

