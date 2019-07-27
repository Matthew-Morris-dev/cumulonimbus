using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{

    public float rotateSpeed = 1;

    public GameObject sun;
    public GameObject moon;
    public GameObject[] stars;

    private bool starsSetActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BasicRotate();
    }

    void BasicRotate()
    {
        this.transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        sun.transform.up = Vector3.up;
        moon.transform.up = Vector3.up;
        if(!starsSetActive && this.transform.eulerAngles.z >= 51)
        {
            //Debug.LogError("we enter here");
            SetStarsActive();
        }
    }

    void SetStarsActive()
    {
        for(int i = 0; i < stars.Length; i++)
        {
            //Debug.LogError("We set star active");
            stars[i].SetActive(true);
        }
        starsSetActive = true;
    }
}
