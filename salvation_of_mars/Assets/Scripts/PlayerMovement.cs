using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMoved = 0;
    public float speed = 40f;
    bool jumping;
    bool active = true;

    // these variables used for cooldown timer to prevent spamming abilities
    float lastReversed;
    float lastBoost;
    float nextReversed;
    float nextBoost;

    bool speedBoostReady, gravityReady;

    float animStarted;

    public Animator animator;

    // used to GET input from player
    // called each time updated
    void Update()
    {
        if(active)
        {
            horizontalMoved = Input.GetAxisRaw("Horizontal") * speed;

            speedBoostReady = false;
            gravityReady = false;

            // set animator to run or idle
            if (animator != null)
            {
                animator.SetFloat("Speed", Mathf.Abs(horizontalMoved));
            }

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            if (Input.GetButtonDown("Fire1")&& SkillSelect.gravitySelected) // activate ability1 (reverse gravity)
            {
                ReverseGrav();
            }
            if (Input.GetButtonDown("Fire2")&& SkillSelect.boostSelected) // activate ability2 (speed/sprint)
            {
                SpeedBoost();
            }
        }
        else
        {
            horizontalMoved = 0;
        }

    }

    // move character in this function
    void FixedUpdate()
    {
        // args: (movement, crouch yes/no, jump yes/no)
        controller.Move(horizontalMoved * Time.fixedDeltaTime, false, jumping);
        jumping = false;

        if((Time.time - 0.02f) > animStarted) // if boost animation should finish, end it
        {
            animator.SetBool("InBoost", false);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("InGravity", false);
    }

    public void ReverseGrav() // called when button to use reverse gravity ability is triggered
    {
        animator.SetBool("InGravity", true);

        if (Time.time > nextReversed) // has cooldown time passed?
        {
            gravityReady = true;

            Physics2D.gravity *= -1;
            controller.reverseGrav = !controller.reverseGrav;
            lastReversed = Time.time;
            nextReversed = lastReversed + 1f; // reset cooldown
        }
    }

    public void SpeedBoost() // called when button to use speed boost ability is triggered
    {
        
        if (Time.time > nextBoost) // has cooldown time passed?
        {
            speedBoostReady = true;

            animator.SetBool("InBoost", true); // starts boost animation 
            animator.SetBool("IsJumping", false); // sets jumping animation to false while in boost animation.
            animStarted = Time.time;

            controller.speedBoost = true;
            lastBoost = Time.time;
            nextBoost = lastBoost + 1f; // reset cooldown
        }

        
    }

    public void Jump()
    {
        jumping = true;
        animator.SetBool("IsJumping", true);
    }


   
    /// <summary>
    /// This is the death method for player
    /// it involves coroutine
    /// </summary>
    public void death()
    {
        StartCoroutine(deathAnimationCoroutine());
    }

    /// <summary>
    /// This method relies on two functions.
    /// The first function allows the animation to play
    /// However we need to essentially Thread.sleep for 1 second
    /// to allow the animation enough time to play all of its frames.
    /// Then we can reload the scene (restart the level after player died)
    /// </summary>
    /// <returns></returns>
    private IEnumerator deathAnimationCoroutine()
    {
        animator.SetBool("isDead", true);

        // Wait 1 second then call the next method
        yield return new WaitForSecondsRealtime(1); 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool isSpeedBoostReady()
    {
        return speedBoostReady;
    }

    public bool isGravityReady()
    {
        return gravityReady;
    }
}
