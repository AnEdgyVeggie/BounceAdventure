using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCylender : MonoBehaviour
{
    [SerializeField]
    private float _speed = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = _speed * Time.deltaTime;

        transform.Rotate(0, velocity, 0);
        //Quaternion turn = Quaternion.Euler(-velocity, -90, -90);
        //transform.rotation = Quaternion.Slerp(transform.rotation, turn, velocity);
    }
}
