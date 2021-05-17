using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI  textTimer;
    public GameObject       winWindow;
    public float timer = 120.0f;
    public bool isTimer;

     
    public Transform Sun;
    public float dayCycleInMinutes;
 
     public const float SECOND = 1;
     public const float MINUTE = 60 * SECOND;
     public const float HOUR = 60 * MINUTE;
     public const float DAY = 24 * HOUR;
     public const float MONTH = 30 * DAY;
     public const float YEAR = 12 * MONTH;
     
     private const float DEGREES_PER_SECOND = 360 / DAY;
     
     private float _degreeRotation;
     
     
     // Use this for initialization
     void Start ()
     {
         isTimer = false;
         StartTimer();
         _degreeRotation = DEGREES_PER_SECOND * DAY / (dayCycleInMinutes * MINUTE);
          Time.timeScale = 1.0f;
     }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (isTimer && DeathTimer.death != true)
        {
            timer -= Time.deltaTime;
            if (timer < 0.1f)
            {
                StopTimer();
                StopAllCoroutines();
                Time.timeScale = 0;
                winWindow.SetActive(true);
            }
            DisplayTime();
            Sun.Rotate(new Vector3(_degreeRotation, 0, 0) * Time.deltaTime);
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
