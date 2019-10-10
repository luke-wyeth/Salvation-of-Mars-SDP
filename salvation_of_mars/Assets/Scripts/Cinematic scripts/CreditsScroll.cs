using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroll : MonoBehaviour
{
    private Vector3 scrollTo;
    // Start is called before the first frame update
    void Start()
    {
        scrollTo = new Vector3(0.15f, -47.59f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, scrollTo, Time.deltaTime * 2f);

        if(this.transform.position == scrollTo) // if the credits have reached the end
        {
            SceneManager.LoadScene(0); // load main menu
        }
    }
}
