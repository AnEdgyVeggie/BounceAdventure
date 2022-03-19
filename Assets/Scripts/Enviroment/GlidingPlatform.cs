using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlidingPlatform : MovingPlatform
{
    [SerializeField]
    GameObject pointA, pointB;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatforms();
    }

    void MovePlatforms()
    {
        float velocity = GetSpeed() * Time.deltaTime;

        if (GetPositionSwitch() == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, velocity);
            if (transform.position == pointA.transform.position)
            {
                SetPositionSwitch(true);
            }
        }
        if (GetPositionSwitch() == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, velocity);
            if (transform.position == pointB.transform.position)
            {
                SetPositionSwitch(false);
            }
        }

    }
}
