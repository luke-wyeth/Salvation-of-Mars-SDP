using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool isActive; // whether you want platform to be moving or not - when this is deactivated, platform will quickly move back to start location and stay there until true
    public bool loop; // when true, platform loops on the path. when false, platform goes from start to end only once (unless deactivated and reactivated)
    public GameObject platform; // drag in the platform object
    public float moveSpeed; // how fast platform moves
    private Transform currentPoint; // point platform is currently heading towards
    public Transform start, end; // start point and end point

    void Start()
    {
        currentPoint = end; // head towards the end point
    }

    void Update()
    {
        if(isActive)
        {
            if(loop)
            {
                if (platform.transform.position == start.position) // if reached the first point, change to head towards second point
                {
                    currentPoint = end;
                }
                if (platform.transform.position == end.position) // if reached second point, change to head back towards first point
                {
                    currentPoint = start;
                }
            }

            // move platform towards target point
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
        }
        else if(!isActive)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, start.position, Time.deltaTime * 5);
        }
        
    }
}
