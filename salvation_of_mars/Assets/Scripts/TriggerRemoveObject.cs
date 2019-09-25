using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRemoveObject : MonoBehaviour
{
    public GameObject objectToRemove; // set as object you want to disable when collider triggered
    public bool permanent; // set TRUE to permanently remove object, FALSE to bring object back when collider exited
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D collision)
    {
        objectToRemove.SetActive(false);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(!permanent)
        {
            objectToRemove.SetActive(true);
        }
    }
}
