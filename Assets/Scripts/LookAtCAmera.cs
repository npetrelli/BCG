using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCAmera : MonoBehaviour
{
     public float angle;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
