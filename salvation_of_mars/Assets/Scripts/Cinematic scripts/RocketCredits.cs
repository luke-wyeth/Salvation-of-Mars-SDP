using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCredits : MonoBehaviour
{
    public Transform left;
    public Transform right;
    private Transform currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = left;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.position == left.position) // if reached the first point, change to head towards second point
        {
            currentPoint = right;
        }
        if (this.transform.position == right.position) // if reached second point, change to head back towards first point
        {
            currentPoint = left;
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, currentPoint.position, Time.deltaTime * 0.7f);
    }
}
