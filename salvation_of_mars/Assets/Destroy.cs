using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // destroys the projectile game object
    private void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);


    }
    private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
                Physics2D.gravity = new Vector2(Physics2D.gravity.x, -(Mathf.Abs(Physics2D.gravity.y)));
                player.reverseGrav = false;
                player.upsidedown = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
}
