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

    public MeshRenderer giantOne;
    public MeshRenderer giantTwo;
    public MeshRenderer giantThree;

    public GameObject walls;

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

    //called once per frame
    void Update()
    {
        //as the score increases, render the large versions of the statues floating above the plane
        if(score == 1)
        {
            giantOne.enabled = true;
        }
        if(score == 2)
        {
            giantTwo.enabled = true;
        }
        if(score == 3)
        {
            giantThree.enabled = true;
            MoveWalls();
        }
    }

    //for adding points to the score
    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    //for disappearing the walls
    public void MoveWalls()
    {
        Destroy(walls);
    }
}
