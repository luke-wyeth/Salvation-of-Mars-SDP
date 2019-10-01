using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float JumpForce = 300f;                          // how much force should player jump with
    [Range(0, 1)] [SerializeField] private float CrouchSpeed = .36f;          // change speed of player movement while crouching
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;  // movement smoothing amount                 
    [SerializeField] private LayerMask WhatIsGround;                          // what counts as the ground? prevent player walking on every layer
    [SerializeField] public Transform GroundCheck;                           // object to check for floor
    [SerializeField] public Transform CeilingCheck;                          // object to check for ceiling
   // [SerializeField] private Collider2D CrouchDisableCollider;                // which collider to disable when player crouches (can go under objects etc)

    const float GroundedRadius = .1f; 
    private bool Grounded;            // is player standing on the ground?
    const float CeilingRadius = .2f; 
    private Rigidbody2D Rigidbody2D;
    private bool FacingRight = true;  // which way is the player facing?
    private Vector3 Velocity = Vector3.zero;
    public bool reverseGrav = false;
    public bool upsidedown = false;
    public bool speedBoost = false;

    private Transform currMovingPlatform;

    public Animator animator;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool wasCrouching = false;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }

        if (OnCrouchEvent == null)
        {
            OnCrouchEvent = new BoolEvent();
        }
    }

    private void FixedUpdate()
    {
        bool wasGrounded = Grounded;
        Grounded = false;

        Debug.Log(Grounded);

        // is grounded if circle overlaps anything designated as ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                Grounded = true;
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
            }
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        // if the player is crouching, can they stand up there?
        if (!crouch)
        {
            // if they shouldn't be able to stand up, must stay crouching
            if (Physics2D.OverlapCircle(CeilingCheck.position, CeilingRadius, WhatIsGround))
            {
                crouch = true;
            }
        }

        // if crouching
        if (crouch)
        {
            if (!wasCrouching)
            {
                wasCrouching = true;
                OnCrouchEvent.Invoke(true);
            }

            move *= CrouchSpeed;

            // disable specified collider when crouching
           // CrouchDisableCollider.enabled = false;
        }
        else
        {
            // enable the collider when not crouching
            //if (CrouchDisableCollider != null)
            //    CrouchDisableCollider.enabled = true;

            if (wasCrouching)
            {
                wasCrouching = false;
                OnCrouchEvent.Invoke(false);
            }
        }

        // move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        Rigidbody2D.velocity = Vector3.SmoothDamp(Rigidbody2D.velocity, targetVelocity, ref Velocity, MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && FacingRight)
        {
            // ... flip the player.
            Flip();
        }
  

        if (reverseGrav && !upsidedown)
        {
            Rotate();
        }
        else if (!reverseGrav && upsidedown)
        {
            Rotate();
        }
        // should the player jump? is gravity normal?
        if (Grounded && jump && !reverseGrav)
        {
            Debug.Log("grounded and jump");
            // jump up
            Grounded = false;
            Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
        }
        // should the player jump? is gravity reversed?
        else if (Grounded && jump && reverseGrav)
        {
            // jump down (reversed grav)
            Grounded = false;
            Rigidbody2D.AddForce(-new Vector2(0f, JumpForce));
        }

        if(speedBoost) // if player has activated speed boost
        {
            if(FacingRight) // player is going right, add positive x force
            {
                Rigidbody2D.AddForce(new Vector2(3000f, Rigidbody2D.velocity.y));
            }
            else if(!FacingRight) // player is going left, add negative x force
            {
                Rigidbody2D.AddForce(-new Vector2(3000f, Rigidbody2D.velocity.y));
            }
           
            speedBoost = false;
        }
    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        // flip player horizontally
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Rotate()
    {
        // flip player vertically
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;

        upsidedown = !upsidedown;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "MovingPlatform")
        {
            currMovingPlatform = coll.gameObject.transform; // set current moving platform to the platform the player collided with
            this.transform.SetParent(currMovingPlatform); // parent platform to player to prevent sliding off
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "MovingPlatform")
        {
            currMovingPlatform = null; // player can now exit platform
        }
    }


     

}