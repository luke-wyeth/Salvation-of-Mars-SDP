using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
/*    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, -(Mathf.Abs(Physics2D.gravity.y)));
            player.reverseGrav = false;
            player.upsidedown = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.death();
        }
    }
}
