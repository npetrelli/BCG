using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    public GameObject[] points;
    public GameObject[] prefabs;
    public ScriptabledObject data;
    int id;
    int count;
    List<int> alreadyGuessed = new List<int>();
    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        for (int i = 0; i < points.Length; i++)
        {
            //Random.seed = System.DateTime.Now.Millisecond;
            id = Random.Range(0, 3);
            count = points[i].transform.childCount;
            if (count == 0)
            {
                GameObject newpref = Instantiate(prefabs[id], new Vector3(points[i].transform.position.x, 
                                prefabs[id].transform.position.y, points[i].transform.position.z), Quaternion.identity);
                newpref.transform.parent = points[i].transform; 
            }

        }
    }
}
