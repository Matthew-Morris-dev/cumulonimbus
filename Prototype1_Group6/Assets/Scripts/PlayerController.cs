using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    string playerTextInput = ""; //Stores the current typed input from the player. Is cleared on a new word.
    string cloudWord = ""; //The word of the cloud; the desired answer to get
    bool isTypingActive = true; //Whether or not the player is allowed to type. Disabled when no word is currently present.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTypingActive)
        {
            AcceptInput();
        }
        print(playerTextInput);
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

    }

    public void SetNewWord(string newWord)
    {
        playerTextInput = "";
        cloudWord = newWord;
    }

    void SpawnUnderScores(int numberOfUnderscores)
    {

    }

}
