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
            // Call the death of the player to restart the scene
            player.GetComponent<PlayerMovement>().death();
       }
    }
}
