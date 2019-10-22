using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.CompareTag("Player"))
       {
            CharacterController2D player = collider.GetComponent<CharacterController2D>();
            // this prevents the player from restarting the level with reversed gravity but upside down stuck in the ground
            // reset gravity to normal gravity, right side up, regardless of current gravity setting
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, -(Mathf.Abs(Physics2D.gravity.y)));
            player.reverseGrav = false;
            player.upsidedown = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       }
    }
}
