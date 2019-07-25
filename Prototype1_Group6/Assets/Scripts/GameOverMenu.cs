using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour
{
    public Image BlackScreen;
    public Text BodyText;
    public float FadeTime;

    void Start()
    {
        BlackScreen.canvasRenderer.SetAlpha(1f);
        FadeOut(FadeTime);

        //used for debugging
        //DisplayGameOverMessage(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fade into black
    public void FadeIn(float speed)
    {
        BlackScreen.canvasRenderer.SetAlpha(0f);
        BlackScreen.CrossFadeAlpha(1f, speed, false);
    }

    //fade out of black
    public void FadeOut(float speed)
    {
        BlackScreen.canvasRenderer.SetAlpha(1f);
        BlackScreen.CrossFadeAlpha(0f, speed, false);
    }

    public void DisplayGameOverMessage(int correct, int total)
    {
        float factorCorrect = float.Parse(correct.ToString()) / float.Parse(total.ToString());
        print(factorCorrect);
        if(factorCorrect > 0.5f)
        {
            BodyText.text = "Congratulations, you got " + correct + " out of " + total + " correct!";
        }
        else
        {
            BodyText.text = "You got " + correct + " out of " + total + " correct! Better luck next time.";
        }
    }

    public void Replay()
    {
        // we might need to change this string as im not sure if that is what it is actually called.
        SceneManager.LoadScene("MainScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
