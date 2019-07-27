using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    public GameObject background;
    public float backgroundLength;
    public Vector3 middleOfBackground;
    public float moveSpeed;
    float spawnInterval;

    GameObject[] backgroundArr = new GameObject [5];
    int mostLeftIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = backgroundLength/moveSpeed;
        for (int i = -2; i < 3; i++)// -2 <= i <= 2
        {
            backgroundArr [i+2] = Instantiate(background, middleOfBackground + new Vector3(backgroundLength, 0, middleOfBackground.z) * i, Quaternion.identity);
        }
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
    }

    void MoveLeft()
    {
        for (int i = 0; i < backgroundArr.Length; i++)
        {
            backgroundArr[i].transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }

    IEnumerator SpawnTimer()
    {
        while (true) //Spooky
        {
            yield return new WaitForSeconds(spawnInterval);
            Destroy(backgroundArr[mostLeftIndex]);
            SpawnNextObj();
            mostLeftIndex++;
            mostLeftIndex = mostLeftIndex % 5;
        }
    }

    void SpawnNextObj()
    {
        backgroundArr[mostLeftIndex] = Instantiate(background, middleOfBackground + new Vector3(backgroundLength, 0, middleOfBackground.z) * 2, Quaternion.identity);
    }


}
