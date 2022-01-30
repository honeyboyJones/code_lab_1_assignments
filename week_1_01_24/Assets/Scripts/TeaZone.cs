using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaZone : MonoBehaviour
{
    public Text teaText; //access the text box

    //called if certain colliders interact
    void OnTriggerEnter(Collider sachet)
    {
        if(sachet.gameObject.tag == "Tea") //if a tea tagged item enters
        {
            //puts this text in the text box, letting the player know they are
            //indeed making some tea
            teaText.text = "YOU'RE MAKING SOME TEA";
        }
    }
}
