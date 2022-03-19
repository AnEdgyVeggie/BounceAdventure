using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    float speed = 2.5f;
    [SerializeField]
    bool positionSwitch = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public float GetSpeed()
    {
        return speed;
    }

    public void SetPositionSwitch(bool positionSwitch)
    {
        this.positionSwitch = positionSwitch;
    }
    public bool GetPositionSwitch()
    {
        return positionSwitch;
    }

}
