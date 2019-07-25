using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject[] cloudObjArr; //Store the cloud prefabs here
    int cloudObjArrSize; //The manual element counter because I don't know how to use dynamic lists, sowwy :<

    GameObject activeCloud; //The cloud doing the floaty float across the screen

    public bool isCloudActive = false; //Whether there is a cloud active in the scene

    public GameObject cloudSpawnPosition; //The gameobject that sets the cloud spawn position   NB: How long the cloud remains on screen can be set on the CloudScript
    public GameObject cloudEndLocation; //The gameobject that sets the cloud destination
    

    // Start is called before the first frame update
    void Start()
    {
        cloudObjArrSize = cloudObjArr.Length;//sets the size of the manual counter
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCloudActive) //If there is no cloud active, and there are still clouds that haven't been spawned, then spawn a cloud.
        {
            if (cloudObjArrSize > 0)
            {
                SpawnNewCloud(Random.Range(0, cloudObjArrSize));
            }
        }
    }

    void SpawnNewCloud(int cloudID)//Spawn cloud, set active cloud flag, and delete that option from the array
    {
        activeCloud = Instantiate(cloudObjArr[cloudID], cloudSpawnPosition.transform.position, Quaternion.identity);
        //activeCloud.GetComponent<CloudScript>().SetEndPos(cloudEndLocation.transform.position);
        isCloudActive = true;
        activeCloud.transform.parent = this.gameObject.transform; //(sets this as the parent of the cloud so CloudScript can easily access this script)
        DeleteFromCloudObjArr(cloudID);
    }

    void DeleteFromCloudObjArr(int deleteID) //Removes the element from the array (but not really because we're using an array and not a list >_<)
    {
        for (int i = deleteID; i < cloudObjArrSize - 1; i++)//Loop from the element to be deleted to 1 before the end, and replace with the next element, ie shift everything after the 'delete' object left by one
        {
            cloudObjArr[i] = cloudObjArr[i + 1];
            //print(cloudObjArr[i].name);
            //print("test");
        }
        cloudObjArrSize--;
    }

    public void SetIsCloudActive(bool value) //a public method to set whether there is an active cloud or not
    {
        isCloudActive = value;
        print("ping");
    }

}
