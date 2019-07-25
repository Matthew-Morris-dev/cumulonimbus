using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndCloudDetectorScript : MonoBehaviour
{
    //Exists purely as a collider script

    public bool isStart;//Sets whether this is the start collider or end collider

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cloud") //if the cloud hits this object
        {
            if (isStart) //if is the starting collider
            {
                GameObject.Find("PlayerControllerObj").GetComponent<PlayerController>().AllowInput(); //Activates typing AND sets the underscores
                print("Hello there");
            }
            else //if is the ending collider
            {
                GameObject.Find("PlayerControllerObj").GetComponent<PlayerController>().CancelInput(); //Deactivates typing AND disables the underscores etc.
                print("General Cloudnobi");
            }
        }
    }
}
