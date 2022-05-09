using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    void OnTriggerEnter(Collider player)
    {
        MuseumManager.instance.Safe();
    }
}
