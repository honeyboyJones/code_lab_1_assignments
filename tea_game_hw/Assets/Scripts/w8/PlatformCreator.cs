using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    public GameObject player; //the player
    public float offset; //offset to tweak how far down the platform is created

    //called once per frame
    void Update()
    {
        //if F key is pressed, do the MakePlatform
        if(Input.GetKeyDown(KeyCode.F))
        {
            MakePlatform();
        }
    }

    void MakePlatform()
    {
        //creates a platform as new game object where the player is located - the y offset
        GameObject platform = Instantiate(Resources.Load("Player Platform")) as GameObject;
        platform.transform.position = new Vector3 
        (
            player.transform.position.x, player.transform.position.y - offset, player.transform.position.z
        );
    }
}
