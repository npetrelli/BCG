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

    int NextGuess(int min, int max)
    {
        int theGuess = Random.Range(min, max);
        while (alreadyGuessed.Contains(theGuess))
            theGuess = Random.Range(min, max);

        alreadyGuessed.Add(theGuess);
        return theGuess;
    }

    public void Spawn()
    {
        for (int i = 0; i < points.Length; i++)
        {
            id = NextGuess(0, 3);
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
