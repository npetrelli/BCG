using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvizibleWalls : MonoBehaviour
{
     public GameObject[]   Walls;
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject gg in Walls)
                gg.SetActive(true);
        }
    }
}
