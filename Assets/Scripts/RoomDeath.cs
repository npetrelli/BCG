﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomDeath : MonoBehaviour
{
    public GameObject[]   Walls;
    bool start;
    int counter;    void Start()
    {
        start = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (start == false)
            {
                DeathTimer.StaartThisShiT();
                start = true;
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
           DeathTimer.StopThisShit();
           start = false;
        }
    }
}