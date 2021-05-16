using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI  textTimer;
    public GameObject       winWindow;
    private float timer = 120.0f;
    private bool isTimer = true;


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (isTimer)
        {
            timer -= Time.deltaTime;
            if (timer == 0.0f)
            {
                isTimer = false;
                winWindow.SetActive(true);
            }
            DisplayTime();
        }
    }

    private void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        isTimer = true;
    }

    public void StopTimer()
    {
        isTimer = false;
    }
}
