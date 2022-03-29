using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeaManager : MonoBehaviour
{
    public int score = 0;
    public int iceScore = 0;
    public int sugarScore = 0;
    //int highscore = 0;

    //begining of singleton pattern
    //had to make public, not sure if correct but it works now
    public static TeaManager instance;
    public static TeaManager GetInstance()
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
    }

    //for adding ice points, at 3, display message and increase overall score by 5
    public void AddIcePoint()
    {
        iceScore += 1;

        if(iceScore == 3)
        {
            score += 5;
        }
    }

    //for adding ice points, at 3, display message and increase overall score by 10
    public void AddSugarPoint()
    {
        sugarScore += 1;

        if(sugarScore == 3)
        {
            score += 10;
        }
    }
}
