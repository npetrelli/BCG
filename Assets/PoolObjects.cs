using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    public GameObject[] points;
    public ScriptabledObject data;
    int id;
    int count;
    private void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            id = Random.Range(0, 3);
            count = points[i].transform.childCount;
            if (count == 0)
            {
                GameObject instrument = Instantiate(data.instrPrefab[id], points[i].transform.position, Quaternion.identity);
                if (instrument != null)
                {
                    //instrument.transform.parent = points[i].transform;
                }
            }

        }
    }
}
