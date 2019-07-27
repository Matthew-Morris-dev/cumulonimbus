using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //This game object survives scene changes
    public static GameManager gameManager;

    public int playerScore; //The player score
    public int totalGuesses;

    private void Awake()//deletes itself if another gamemanager already exists, otherwise this becomes the static gamemanager
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(int scoreAmount) //Adds to the score
    {
        playerScore += scoreAmount;
    }

    public void GameOver()
    {
        print("gg wp no re");
        SceneManager.LoadScene("GameOverScene"); //Go to end scene
    }
}
