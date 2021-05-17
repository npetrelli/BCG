using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathTimer : MonoBehaviour
{
    private static DeathTimer instance;
    private static TextMeshProUGUI  text;
    private static Coroutine lastRoutine = null;
    public GameObject GameOver;
    private static GameObject gg;
    static int counter;
    public static bool death;
    public static bool start;
    public static bool win;
    public static bool mainStart;
    
    void Start()
    {
        mainStart = false;
        win = false;
        start = false;
        gg = GameOver;
        death = false;
        instance = this;
        text = GetComponent<TextMeshProUGUI>();
        counter = 21;
    }
    public static void StaartThisShiT()
    {
        lastRoutine = instance.StartCoroutine(Countdown(21));
        counter = 21;
    }

    public static void StopThisShit()
    {
        if (lastRoutine != null)
            instance.StopCoroutine(lastRoutine);
    }


    static void DoStuff () {
        death = true;
        instance.Invoke("GG", 2);
    }

    void GG()
    {
        gg.SetActive(true);
    }
    
    static IEnumerator Countdown (int seconds)
    {
        counter = seconds;
        while (counter > 0 && win == false)
        {
            yield return new WaitForSecondsRealtime(1);
            counter--;
            if (counter < 0)
                counter = 0;
            int minutes = Mathf.FloorToInt(counter / 60);
            int second = Mathf.FloorToInt(counter - minutes * 60);
            text.text = string.Format("{0:00}:{1:00}", minutes, second);
        }
        if (win == false)
            DoStuff();
    }
}
