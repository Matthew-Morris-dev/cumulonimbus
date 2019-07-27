using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject[] underscorePrefabArr; //Store the underscore prefabs here. Methods will display a random one.
    public GameObject[] alphabetPrefabArr; //Store the alphabet prefabs here. Methods will display them as needed.

    string playerTextInput = ""; //Stores the current typed input from the player. Is cleared on a new word.
    string cloudWord = ""; //The word of the cloud; the desired answer to get
    bool isTypingActive = true; //Whether or not the player is allowed to type. Disabled when no word is currently present.

    float horizontalLevelSpace = 18; //The screen size in units. Currently unused.

    GameObject[] underscoreArray = new GameObject[10]; //The gameobject array that VISUALLY displays the underscores.
    GameObject[] alphabetArray = new GameObject[10]; //The gameobject array that VISUALLY displays the player text. Relies on underscore position.
    GameObject[] correctWordArray = new GameObject[10]; //The gameobject array that VISUALLY displays the correct word.


    //how to play stuff
    [SerializeField]
    private bool howToPlay = false;
    [SerializeField]
    private int stage = 1;
    [SerializeField]
    private CloudScript cloud;
    [SerializeField]
    private HowToPlayController HTPC;

    //Pause menu stuff
    private bool paused = false;
    [SerializeField]
    private GameObject pauseMenuUI;


    // Start is called before the first frame update
    void Start()
    {
        if (howToPlay)
        {
            if (cloud == null)
            {
                cloud = FindObjectOfType<CloudScript>();
            }
            if (HTPC == null)
            {
                HTPC = FindObjectOfType<HowToPlayController>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (howToPlay)
        {
            if (cloud == null)
            {
                cloud = FindObjectOfType<CloudScript>();
            }
            if (HTPC == null)
            {
                HTPC = FindObjectOfType<HowToPlayController>();
            }
            else
            {
                if ((stage == 1) && GetCloudPosition(cloud) <= (Screen.width * 0.75))
                {
                    //we enter stage 1
                    //Debug.LogWarning("We enter stage 1");
                    Time.timeScale = 0f;
                    HTPC.RenderKeyboard(stage);
                    if (Input.GetKeyDown(KeyCode.C) && !paused)
                    {
                        playerTextInput += 'C';
                        UpdatePlayerText();
                        //Debug.LogWarning("Player pressed c");
                        stage = 2;
                        Time.timeScale = 1f;
                        HTPC.RenderKeyboard(0);
                    }
                }
                else if ((stage == 2) && GetCloudPosition(cloud) <= (Screen.width * 0.5))
                {
                    Time.timeScale = 0f;
                    HTPC.RenderKeyboard(stage);
                    if (Input.GetKeyDown(KeyCode.A) && !paused)
                    {
                        playerTextInput += 'A';
                        UpdatePlayerText();
                        //Debug.LogWarning("Player pressed a");
                        stage = 3;
                        Time.timeScale = 1f;
                        HTPC.RenderKeyboard(0);
                    }
                }
                else if ((stage == 3) && GetCloudPosition(cloud) <= (Screen.width * 0.25))
                {
                    Time.timeScale = 0f;
                    HTPC.RenderKeyboard(stage);
                    if (Input.GetKeyDown(KeyCode.T) && !paused)
                    {
                        playerTextInput += 'T';
                        UpdatePlayerText();
                        //Debug.LogWarning("Player pressed t");
                        stage = 4;
                        Time.timeScale = 1f;
                        HTPC.RenderKeyboard(0);
                    }
                    if (cloudWord.Length > 0 && cloudWord.Length == playerTextInput.Length)//If the player answer is the same length as the actual answer
                    {
                        if (cloudWord == playerTextInput) //if the answer is correct
                        {
                            WordCorrect();
                        }
                        else //if the answer is WRONG
                        {
                            StartCoroutine(WordWrong());
                        }
                    }
                }
                else
                {
                    if(GetCloudPosition(cloud) < 0f)
                    {
                        Invoke("EndHowToPlay", 0.25f);
                    }
                }
            }
        }
        else
        {
            if (isTypingActive && !paused)
            {
                AcceptInput();
            }
        }
        //print(playerTextInput);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePaused();
        }
    }

    void AcceptInput() //The method to accept player input. Letters and Backspace/Enter are valid inputs.
    {


        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            print("backspace");
            //remove a letter. (to do: ensure it does not become less than zero)
            if (playerTextInput.Length > 0)
            {
                playerTextInput = playerTextInput.Remove(playerTextInput.Length - 1, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Test whether the player answer equals the cloud answer

        }

        if (playerTextInput.Length < cloudWord.Length)//Ensures that the player may not enter more than the available numbers of letters in the cloud word
        { //All 26 input letters under this if
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerTextInput += 'A';

            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                playerTextInput += 'B';

            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                playerTextInput += 'C';

            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                playerTextInput += 'D';

            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerTextInput += 'E';

            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                playerTextInput += 'F';

            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                playerTextInput += 'G';

            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                playerTextInput += 'H';

            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                playerTextInput += 'I';

            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                playerTextInput += 'J';

            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                playerTextInput += 'K';

            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                playerTextInput += 'L';

            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                playerTextInput += 'M';

            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                playerTextInput += 'N';

            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                playerTextInput += 'O';

            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                playerTextInput += 'P';

            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerTextInput += 'Q';

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                playerTextInput += 'R';

            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                playerTextInput += 'S';

            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                playerTextInput += 'T';

            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                playerTextInput += 'U';

            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                playerTextInput += 'V';

            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                playerTextInput += 'W';

            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                playerTextInput += 'X';

            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                playerTextInput += 'Y';

            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                playerTextInput += 'Z';

            }
        }

        if (Input.anyKeyDown) //If a button is pressed, update the physical text display. More efficient than doing it every update
        {
            UpdatePlayerText();
            if (cloudWord.Length > 0 && cloudWord.Length == playerTextInput.Length)//If the player answer is the same length as the actual answer
            {
                if (cloudWord == playerTextInput) //if the answer is correct
                {
                    WordCorrect();
                }
                else //if the answer is WRONG
                {
                    StartCoroutine(WordWrong());
                }
            }
        }
    }

    public void SetNewWord(string newWord) //Sets the new cloud word
    {
        cloudWord = newWord;
    }

    void SpawnUnderscores(int numberOfUnderscores)//Spawns the VISUAL underscores. Positioning is based on the length of the word. !!NB Change the gap distance and middle position here!!
    {
        Vector3 middleOfWordPos = new Vector3(0, -4.5f, 0); //Where the middle of the word should be on screen
        float gapSpace = 2.4f; //How far one letter is from the next
        if (numberOfUnderscores%2 == 0)//if Even
        {
            middleOfWordPos -= Vector3.right * (numberOfUnderscores / 2 - 1) * gapSpace + Vector3.right * gapSpace * 0.5f; //Set the 'start' position of the first underscore (to be symmetrical)

            for (int i = 0; i < numberOfUnderscores; i++)
            {
                underscoreArray[i] = Instantiate(underscorePrefabArr[Random.Range(0, underscorePrefabArr.Length)], middleOfWordPos + Vector3.right * i * gapSpace, Quaternion.identity);
            }
        }
        else //if Odd
        {
            middleOfWordPos -= Vector3.right * (numberOfUnderscores / 2) * gapSpace; //Set the 'start' position of the first underscore (to be symmetrical)
            for (int i = 0; i < numberOfUnderscores; i++)
            {
                underscoreArray[i] = Instantiate(underscorePrefabArr[Random.Range(0, underscorePrefabArr.Length)], middleOfWordPos + Vector3.right * i * gapSpace, Quaternion.identity);
            }
        }
    }

    void DeleteUnderscores() //Removes the VISUAL underscores from the screen
    {
        for (int i = 0; i < underscoreArray.Length; i++)
        {
            Destroy(underscoreArray[i]);
        }
    }

    public void AllowInput() //Let the player type, AND spawns in the underscores for the word.
    {
        isTypingActive = true;
        SpawnUnderscores(cloudWord.Length);
    }

    public void CancelInput() //Clear word, disable typing, remove underscores;
    {
        isTypingActive = false;
        playerTextInput = "";
        UpdatePlayerText();
        DeleteUnderscores();

    }

    void UpdatePlayerText() //Update the VISUAL player text input. Is dependant on the position of the underscores
    {
        float distanceAboveUnderscore = 1f;
        if (playerTextInput.Length > 0)
        {
            for (int i = 0; i < playerTextInput.Length; i++)
            {
                if (alphabetArray[i] == null)
                {
                    alphabetArray[i] = Instantiate(alphabetPrefabArr[playerTextInput[i] - 65], underscoreArray[i].transform.position + Vector3.up * distanceAboveUnderscore, Quaternion.identity);
                }
            }
            for (int i = playerTextInput.Length; i < alphabetArray.Length; i++)
            {
                if (alphabetArray[i] != null)
                {
                    Destroy(alphabetArray[i]);
                }
            }
        }
        else
        {
            for (int i = 0; i < alphabetArray.Length; i++)
            {
                if (alphabetArray[i] != null)
                {
                    Destroy(alphabetArray[i]);
                }
                
            }
        }
    }

    IEnumerator WordWrong() //A coroutine to run when the player gets the word wrong.
    {
        isTypingActive = false;
        ColourAlphabet(1);
        yield return new WaitForSeconds(0.5f);
        playerTextInput = "";
        UpdatePlayerText();
        isTypingActive = true;
        print("Word is WRONG!");
    }

    void WordCorrect() //A method to run when the player gets the word right.
    {
        GameManager.gameManager.AddToScore(1);
        isTypingActive = false;
        //Play ding noise
        ColourAlphabet(2);
        GameObject.Find("CloudSpawnerObj").GetComponent<CloudSpawnerScript>().SpeedUpCloud(5); //Dependant on a CloudSpawnerObject !!NB!! Change the speed value here!
        print("Word is RIGHT!");
        //yield return new WaitForSeconds(0.5f);
    }

    void ColourAlphabet(int choice) //0 for a white alphabet, 1 for a red alphabet, 2 for a green alphabet
    {
        switch (choice)
        {
            case 0: //White colour
            for (int i = 0; i < alphabetArray.Length; i++)
            {
                    if (alphabetArray[i] != null)
                    {
                        alphabetArray[i].GetComponent<SpriteRenderer>().color = Color.white;
                    }
            }
                break;
            case 1: //Red colour
                for (int i = 0; i < alphabetArray.Length; i++)
                {
                    if (alphabetArray[i] != null)
                    {
                        alphabetArray[i].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
                break;
            case 2:
                for (int i = 0; i < alphabetArray.Length; i++)
                {
                    if (alphabetArray[i] != null)
                    {
                        alphabetArray[i].GetComponent<SpriteRenderer>().color = Color.green;
                    }
                }
                break;
        }
    }

    public void DisplayCorrectWord() //Checks if the answer is wrong (aka the player can still type), then displays the word for a little
    {
        if (isTypingActive)
        {
            float distanceAboveUnderscore = 7f;
            for (int i = 0; i < cloudWord.Length; i++)
            {
                correctWordArray[i] = Instantiate(alphabetPrefabArr[cloudWord[i] - 65], underscoreArray[i].transform.position + Vector3.up * distanceAboveUnderscore, Quaternion.identity);
                //if (Time.timeSinceLevelLoad > 40)
                correctWordArray[i].GetComponent<SpriteRenderer>().color = Color.grey;
                Destroy(correctWordArray[i], 2f);
            }
        }
    }

    #region HowToPlay Scripts

    private float GetCloudPosition(CloudScript obj)
    {
        Debug.LogError(Camera.main.WorldToScreenPoint(obj.transform.position));
        Vector3 Pos = Camera.main.WorldToScreenPoint(obj.transform.position);
        return Pos.x;
    }
    
    private void EndHowToPlay()
    {
        SceneManager.LoadScene("MainScene");
    }

    #endregion

    #region PauseMenu Scripts

    public void TogglePaused()
    {
        if(paused)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
        }
        else
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
