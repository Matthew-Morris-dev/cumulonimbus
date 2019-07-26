using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
   
    void Awake()
    {
       
        if (FadeEffect.instance != null)
        {
            FadeEffect.instance.FadeOut(0.5f);
        }
    }

    public void DelayedPlayGame()
    {
        if (FadeEffect.instance != null)
        {
            FadeEffect.instance.FadeIn(0.5f);
        }
        Time.timeScale = 1f;
        Invoke("PlayGame", 0.5f);
    }

    public void DelayedQuitGame()
    {
        if (FadeEffect.instance != null)
        {
            FadeEffect.instance.FadeIn(0.5f);
        }
        Invoke("Quit", 0.5f);
    }

    public void DelayedTutorial()
    {
        if (FadeEffect.instance != null)
        {
            FadeEffect.instance.FadeIn(0.5f);
        }
        Invoke("PlayTutorial", 0.5f);
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
