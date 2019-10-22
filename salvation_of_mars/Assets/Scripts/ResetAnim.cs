using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnim : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        resetAnimations();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetAnimations()
    {
        player.SetActive(false);
        player.SetActive(true);
    }
}
