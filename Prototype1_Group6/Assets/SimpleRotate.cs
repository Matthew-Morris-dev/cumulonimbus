using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{

    float rotateSpeed = 1;
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
    }
}
