using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniTimer : MonoBehaviour
{
    [HideInInspector] public Image fillImage;
    float timeAmt = 10;
    float time;
    public GameObject   wall;
    public bool         pause = false;
    public ScriptabledObject    data;
    
    public PoolObjects          poolObjects;
    public void Timer()
    {
        fillImage = GetComponent<Image>();
        time = timeAmt;
        StartCoroutine(Countdown());  
    }

    private IEnumerator Countdown()
    {
        float duration = 3f;
        float totalTime = 0;
        while (totalTime <= duration && !pause)
        {
            fillImage.fillAmount = totalTime / duration;
            totalTime += Time.deltaTime;
            var integer = (int)totalTime; /* choose how to quantize this */
            /* convert integer to string and assign to text */
            yield return null;
            if (totalTime > duration)
            {
                Beating beating = wall.GetComponent<Beating>();
                data.instruments[beating.id] = false;
                SetActive.SetDisactiveMethod(beating.id);
                wall.SetActive(false);
                PlayerPrefs.SetInt("Beat", 0);
                foreach (GameObject beat in beating.walls)
                    beat.SetActive(false);
                fillImage.fillAmount = 0;
                beating.click.SetActive(false);
                poolObjects.Spawn();
            }
        }
    }
}
