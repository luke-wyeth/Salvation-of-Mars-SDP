using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public float speedFactor;
    public float Delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoots());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shoots()
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);

            GameObject Projectile_Clone = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);

            Projectile_Clone.GetComponent<Rigidbody2D>().velocity = -transform.right * speedFactor;           
        }

    }
}
