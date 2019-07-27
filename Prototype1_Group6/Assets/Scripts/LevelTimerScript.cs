using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimerScript : MonoBehaviour
{

    float levelMaxTime = 60; //in seconds !!NB!! The level length is set here
    float currLevelTime = 0;



    //STILL TO DO LIST: Sun and moon, Parallax background script.
    //In charge of how long the level lasts AND (probably) for rotating the sun/moon around
    // Start is called before the first frame update
    void Start()
    {
        currLevelTime = 0;
        GameManager.gameManager.playerScore = 0;
        GameManager.gameManager.totalGuesses = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LevelCountdown();
        
    }

    void LevelCountdown()
    {
        currLevelTime += Time.deltaTime;
        if (currLevelTime > levelMaxTime)
        {
            //GameManager.gameManager.GameOver();
            //print("LAST CLOUD FRIENDS!!");
            GameObject.Find("CloudSpawnerObj").GetComponent<CloudSpawnerScript>().ClearCloudArrSize();
        }
    }
}
