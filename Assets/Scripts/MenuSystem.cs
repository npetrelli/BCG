using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("sound", 1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SetSound()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            AudioListener.pause = true;
            PlayerPrefs.SetInt("sound", 0);
        }
        else
        {
            AudioListener.pause = false;
            PlayerPrefs.SetInt("sound", 1);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Close(GameObject gg)
    {
        gg.SetActive(false);
    }

    public void Open(GameObject gg)
    {
        gg.SetActive(true);
    }

    public void LoadGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
