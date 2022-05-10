using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    //when player collider enters safe zone, they are Safe()
    void OnTriggerEnter(Collider player)
    {
        MuseumManager.instance.Safe();
    }
}
