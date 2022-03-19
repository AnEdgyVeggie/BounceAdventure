using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPillar : MovingPlatform
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
        float platformVelocity = GetSpeed() * Time.deltaTime;

        if (GetPositionSwitch() == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, platformVelocity);

            if (transform.position == pointA.transform.position)
            {
                SetPositionSwitch(true);
            }
        }
        else if (GetPositionSwitch() == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, platformVelocity);
            if (transform.position == pointB.transform.position)
            {
                SetPositionSwitch(false);
            }
        }

    }


}
