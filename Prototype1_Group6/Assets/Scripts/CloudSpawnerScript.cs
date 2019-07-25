using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject[] cloudObjArr;
    int cloudObjArrSize;

    GameObject activeCloud; //The cloud doing the floaty float across the screen

    public bool isCloudActive = false;

    public GameObject cloudSpawnPosition;
    public GameObject cloudEndLocation;

    // Start is called before the first frame update
    void Start()
    {
        cloudObjArrSize = cloudObjArr.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCloudActive)
        {
            if (cloudObjArrSize > 0)
            {
                SpawnNewCloud(Random.Range(0, cloudObjArrSize));
            }
        }
    }

    void SpawnNewCloud(int cloudID)//Spawn cloud, and delete that option from the array
    {
        activeCloud = Instantiate(cloudObjArr[cloudID], cloudSpawnPosition.transform.position, Quaternion.identity);
        //activeCloud.GetComponent<CloudScript>().SetEndPos(cloudEndLocation.transform.position);
        isCloudActive = true;
        activeCloud.transform.parent = this.gameObject.transform;
        DeleteFromCloudObjArr(cloudID);
    }

    void DeleteFromCloudObjArr(int deleteID)
    {
        for (int i = deleteID; i < cloudObjArrSize - 1; i++)//Loop from the element to be deleted to 1 before the end, and replace with the next element
        {
            cloudObjArr[i] = cloudObjArr[i + 1];
            //print(cloudObjArr[i].name);
            //print("test");
        }
        cloudObjArrSize--;
    }

    public void SetIsCloudActive(bool value)
    {
        isCloudActive = value;
        print("ping");
    }

}
