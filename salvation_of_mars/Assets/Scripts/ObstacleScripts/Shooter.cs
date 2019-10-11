using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public float speedFactor;
    public float Delay;
    public volatile bool isActive; // setting this to false will stop projectiles from firing

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoots());
    }

    IEnumerator Shoots()
    {
        while(true) // loop forever
        {
            if(isActive) // if turret is currently active
            {
                yield return new WaitForSeconds(Delay);

                Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.5f);
                // instantiate a projectile
                GameObject Projectile_Clone = (GameObject)Instantiate(projectile, position, Quaternion.identity);

                // shoot the projectile
                Projectile_Clone.GetComponent<Rigidbody2D>().velocity = -transform.right * speedFactor;
            }

            // wait for 0.2 seconds: this prevents getting in an infinite loop and crashing 
            yield return new WaitForSeconds(0.2f);
        }
    }
}
