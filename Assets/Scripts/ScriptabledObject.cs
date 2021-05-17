using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScriptabledObject", order = 1)]
public class ScriptabledObject : ScriptableObject
{
   public Material[] material;
   public bool[]     instruments;
   public GameObject[] instrPrefab;

   public string[]   audioClips = {"wood", "metal", "brick"};
}


