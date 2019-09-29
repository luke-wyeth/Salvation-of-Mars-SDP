using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public GameObject targetPos;
    private bool flying;
    public GameObject player;
    public GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        flying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(flying)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos.transform.position, Time.deltaTime * 10);
        }
    }
        

    private void OnCollisionEnter2D(Collision2D collision)
    {
        setFlying();
    }

    private void setFlying()
    {
        flying = true;
        player.SetActive(false); // disable the player
        clone.SetActive(false); // disable the clone
    }
}
