using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathTimer : MonoBehaviour
{
    private static DeathTimer instance;
    private static TextMeshProUGUI  text;
    private static Coroutine lastRoutine = null;
    static int counter;
    public static bool death;
    
    void Start()
    {
        death = false;
        instance = this;
        text = GetComponent<TextMeshProUGUI>();
        counter = 20;
    }
    public static void StaartThisShiT()
    {
        lastRoutine = instance.StartCoroutine(Countdown(20));
        counter = 20;
    }

    public static void StopThisShit()
    {
        instance.StopCoroutine(lastRoutine);
    }


    static void DoStuff () {
        death = true;
    }
    
    static IEnumerator Countdown (int seconds)
    {
        counter = seconds;
        while (counter > 0) {
            yield return new WaitForSecondsRealtime(1);
            counter--;
            int minutes = Mathf.FloorToInt(counter / 60);
            int second = Mathf.FloorToInt(counter - minutes * 60);
            text.text = string.Format("{0:00}:{1:00}", minutes, second);
        }
        DoStuff ();
    }
}
