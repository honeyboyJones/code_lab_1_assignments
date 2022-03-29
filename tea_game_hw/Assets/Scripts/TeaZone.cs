using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeaZone : MonoBehaviour
{
    public TMP_Text scoreText; //access the TMP score text box
    public TMP_Text teaText; //access the TMP tea text box
    public TMP_Text highScore; //access the TMP tea text box

    public TMP_Text iceText; //access the TMP tea text box
    public TMP_Text sugarText; //access the TMP tea text box


    //sets the highscore so that it is visible from the beginning
    void Start()
    {
        //gets the highscore from the set (below) and converts to string for use in the text box
        highScore.text = "THE HIGHEST OF SCORES IS " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    //called if certain tagged colliders interact, namely the Ice, Sugar, and Tea
    void OnTriggerEnter(Collider sachet)
    {
        if(sachet.gameObject.tag == "Ice") //if an ice tagged item enters
        {
            print("ICE ICE BABY");
            TeaManager.instance.AddIcePoint();

            //update UI with the tea manager
            if(TeaManager.instance.iceScore > 2)
            {
                iceText.text = "YOU'RE BALANCING OUT THE TEMPERATURE NICELY";
            }
        }

        if(sachet.gameObject.tag == "Sugar") //if a sugar tagged item enters
        {
            print("SWEET");
            TeaManager.instance.AddSugarPoint();

            //update UI with the tea manager
            if(TeaManager.instance.sugarScore > 2)
            {
                sugarText.text = "YOU'RE SWEETENING THE TEA JUST RIGHT";
            }
        }

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
                teaText.text = "WOW, YOU'RE MAKING SOME STRONG TEA";
            }
        }

        //if the current score is higher than the high score, set the highscore to this new
        //score. also updates the highscore text as this happens (i still think there's a 
        //better way to contain the whole TeaManager.instance.score situation)
        if(TeaManager.instance.score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", TeaManager.instance.score);
            highScore.text = "THE HIGHEST OF SCORES IS " + PlayerPrefs.GetInt("highscore", 0).ToString();
        }
    }

    void Update()
    {
        //resets the highscore when the player presses the T key
        if(Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.DeleteKey("highscore");
            highScore.text = "THE HIGHEST OF SCORES IS 0";
            //print("WORKING");
        }
    }
}