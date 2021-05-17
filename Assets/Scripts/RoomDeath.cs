using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomDeath : MonoBehaviour
{
    bool start;
    Coroutine ins;

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
                ins = StartCoroutine(DeathTimer.Countdown(21));
                start = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopCoroutine(ins);
            start = false;
        }
    }
}
