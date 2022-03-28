using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    public GameObject player;
    public float offset;

    //called before the first frame update
    void Start()
    {
        
    }

    //called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            MakePlatform();
        }
    }

    void MakePlatform()
    {
        GameObject platform = Instantiate(Resources.Load("Player Platform")) as GameObject;
        platform.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y - offset, player.transform.position.z);
    }
}
