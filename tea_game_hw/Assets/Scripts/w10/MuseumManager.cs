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
    public TMP_Text messageText;

    public MeshRenderer giantOne;
    public MeshRenderer giantTwo;
    public MeshRenderer giantTwo2;
    public MeshRenderer giantThree;

    public GameObject walls;

    public NPCController NPC;
    //public GameObject safeZone;

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
        //after the first butt is touched, set george loose to chase the player
        if(score == 1)
        {
            giantOne.enabled = true;
            NPC.ActivateGeorge();
            print("CHASING");
        }
        if(score == 2)
        {
            giantTwo.enabled = true;
            giantTwo2.enabled = true;
        }
        if(score == 3)
        {
            giantThree.enabled = true;
            //MoveWalls();
        }
    }

    //for adding points to the score
    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    //for disappearing the walls, no longer used
    public void MoveWalls()
    {
        Destroy(walls);
    }

    //turns off george and prints YOU WIN
    public void Safe()
    {
        NPC.DeactivateGeorge();
        messageText.text = "YOU WIN";
    }

    //turns off george and prints YOU LOSE
    public void Caught()
    {
        NPC.DeactivateGeorge();
        messageText.text = "YOU LOSE";
    }
}
