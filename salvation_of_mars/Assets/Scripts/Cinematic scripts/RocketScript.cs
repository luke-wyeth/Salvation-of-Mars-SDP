using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public GameObject targetPos;
    private bool flying;
    public GameObject player;
    public GameObject clone;
    public GameObject flame;
    private float timeEnabled;

    // Start is called before the first frame update
    void Start()
    {
        flying = false;
        flame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(flying)
        {
            if((Time.time - 0.5) > timeEnabled) // delay before start flying away
            {
                flame.SetActive(true); // enable the flame under the rocket
                // move towards end position
                this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos.transform.position, Time.deltaTime * 10);
            }

            if((Time.time - 4f) > timeEnabled)
            {
                toCredits();
            }
        }
    }
        

    private void OnTriggerEnter2D()
    {
        // when the player collides with the rocket, start the flying sequence
        setFlying();
    }

    private void setFlying()
    {
        timeEnabled = Time.time;
        flying = true; // set boolean
        player.SetActive(false); // disable the player
        clone.SetActive(false); // disable the clone
    }

    private void toCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
