using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTea : MonoBehaviour
{
    //destroy tea sachet if it collides with the terrain
    void OnCollisionEnter(Collision terrain)
    {
        if(terrain.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }
}
