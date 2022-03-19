using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ungrounded : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponentInChildren<Player>();
            player.GroundPlayer(false);
        }
    }
}
