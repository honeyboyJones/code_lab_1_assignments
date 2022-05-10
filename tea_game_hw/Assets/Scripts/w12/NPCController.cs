using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathUtil;
using Pathfinding;

public class NPCController : MonoBehaviour
{
    //references
    GameObject player;

    //public GameObject nameCanvas;
    public float sight;

    Seeker seeker;
    Path path;
    CharacterController controller;

    public AudioClip chaseSound;
    public AudioSource chaseSource;

    public float speed;
    public float nextDistance;
    int currentWaypoint;
    bool reachedEnd;

    //called before the first frame update
    void Start()
    {
        //finds the player, seeker, and character controller for george
        player = GameObject.Find("Player");

        seeker = GetComponent<Seeker>();
        controller = GetComponent<CharacterController>();
    }

    //sets george on the path toward the player, starts playing chase audio
    public void ActivateGeorge()
    {
        seeker.StartPath(transform.position, player.transform.position, OnPathComplete);
        PlayChaseSound();
    }

    //stops george's movement, stops chase audio
    public void DeactivateGeorge()
    {
        speed = 0f;
        //print("YOU WIN");
        chaseSource.Stop();
    }

    //if the chase audio isn't playing, play the audio clip when called
    void PlayChaseSound()
    {
        chaseSource.clip = chaseSound;
        if(!chaseSource.isPlaying)
        {
            chaseSource.Play();
        }
    }

    //called once per frame
    void Update()
    {
        if(Util.CanSeeObj(player, gameObject, sight))
        {
            print("I CAN SEE THE PLAYER");
        }

        Util.ObjSide(player, gameObject);

        //nameCanvas.transform.forward = Camera.main.transform.forward;

        //if there is no path, return
        //this is taken from the A* video, still learning about its function
        if(path == null)
        {
            return;
        }
        reachedEnd = false;
        float distanceToWayPoint;
        while(true)
        {
            distanceToWayPoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if(distanceToWayPoint < nextDistance)
            {
                if(currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else reachedEnd = true;
                break;
            }
            else break;
        }

        float speedSmooth;
        if(reachedEnd)
        {
            speedSmooth = Mathf.Sqrt(distanceToWayPoint / nextDistance); //square root != squirt
        }
        else speedSmooth = 1;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        Vector3 vel = dir * speed * speedSmooth;
        controller.SimpleMove(vel);
    }

    void OnPathComplete(Path p)
    {
        print("FOUND PATH");
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    //if george collides with the player, run Caught()
    void OnCollisionEnter(Collision player)
    {
        MuseumManager.instance.Caught();
    }
}
