using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    private static SetActive    instance;
    public Image[]               image;
    private static Image[]        image1; 


    private void Awake() {
        instance = this;
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        image1 = image;
    }

    public static void SetActiveMethod(int id)
    {
        image1[id].color = Color.white;
    }

    public static void SetDisactiveMethod(int id)
    {
        image1[id].color = Color.black;
    }
}
