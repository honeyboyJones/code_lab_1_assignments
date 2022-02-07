using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeaZone : MonoBehaviour
{
    public TMP_Text scoreText; //access the TMP score text box
    public TMP_Text teaText; //access the TMP tea text box

    //called if certain colliders interact
    void OnTriggerEnter(Collider sachet)
    {
        if(sachet.gameObject.tag == "Tea") //if a tea tagged item enters
        {
            //update UI with the tea manager
            TeaManager.instance.AddPoint();
            
            //if the score is 1 (there's probably a more concise way to reference the 
            //score from the tea manager but this works for now)
            if(TeaManager.instance.score == 1)
            {
                scoreText.text = TeaManager.instance.score.ToString() + " POINT";
            }
            //if the score is greater than 1, make point plural and indicate to the
            //player that they are making some strong tea
            if(TeaManager.instance.score > 1)
            {
                scoreText.text = TeaManager.instance.score.ToString() + " POINTS";

                //puts this text in the text box, letting the player know they are
                //indeed making some strong tea
                teaText.text = "YOU'RE MAKING SOME STRONG TEA";
            }
        }
    }
}
