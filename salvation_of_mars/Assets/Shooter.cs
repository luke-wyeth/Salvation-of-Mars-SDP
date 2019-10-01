using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public float speedFactor;
    public float Delay;
    public bool isActive; // setting this to false will stop projectiles from firing

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

                GameObject Projectile_Clone = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);

                Projectile_Clone.GetComponent<Rigidbody2D>().velocity = -transform.right * speedFactor;
            }
        }
    }
}
