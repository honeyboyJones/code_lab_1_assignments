using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MuseumManager : MonoBehaviour
{
    //references
    public int score = 0;
    public TMP_Text scoreText;

    //begining of singleton pattern
    public static MuseumManager instance;
    public static MuseumManager GetInstance()
    {
        return instance;
    }

    //called first, before application starts
    void Awake()
    {
        //if there is already a main manager, (if instance is
        //not nothing and if the main instance is not this instance)
        //destroy this
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        //otherwise, if there is not a main manager, then make this
        //the main manager and do not destroy it when new scenes
        //are loaded
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //for adding points to the score
    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
}
