using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomDeath : MonoBehaviour
{
    bool start;
    
    private void Start()
    {
        start = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (start == false)
            {
                StopAllCoroutines();
                DeathTimer.StaartThisShiT();
                start = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            DeathTimer.StopThisShit();
            start = false;
        }
    }
}
