using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public string cloudAnswerCAPS; //ALL CAPS PLEASE
    GameObject playerObj; //To send the word to

    //float moveSpeed = 2f; //Use this to use a cloud speed
    Vector3 startPos;
    Vector3 endPos;

    float lerpTime; //Use this to use a cloud duration
    float currLerp;

    void Start()
    {
        startPos = this.transform.position;
        endPos = this.transform.parent.GetComponent<CloudSpawnerScript>().cloudEndLocation.transform.position;

        currLerp = 0;
        lerpTime = 13;
        //lerpTime = (startPos - endPos).magnitude / moveSpeed; //How long it should take to reach the destination.

        GameObject.Find("PlayerControllerObj").GetComponent<PlayerController>().SetNewWord(cloudAnswerCAPS); //Give the playerController the new word
    }

    // Update is called once per frame
    void Update()
    {
        moveToEnd();
    }

    void moveToEnd() //Moves the object towards the end pos using lerp
    {
        //this.transform.position = this.transform.position + Vector3.left * moveSpeed * Time.deltaTime; //Basic bitch movement

        currLerp += Time.deltaTime / lerpTime;
        this.transform.position = Vector3.Lerp(startPos, endPos, currLerp);

        if (currLerp >= 1)//if the cloud reaches the end of its journey, tell the spawner it is being deleted, then delete.
        {
            this.transform.parent.GetComponent<CloudSpawnerScript>().SetIsCloudActive(false);
            Destroy(this.gameObject);
        }
    }

    public void SetEndPos(Vector3 pos) //A public method to set the end lerp position (Unused I think)
    {
        endPos = pos;
    }

    public void ShortenTravelTime(float multiplier)
    {
        lerpTime = lerpTime / multiplier;
    }

}
