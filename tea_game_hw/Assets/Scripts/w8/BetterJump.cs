using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f; //multiplier for the gravity once falling
    public float lowJumpMultiplier = 2f; //multiplier for the gravity once falling from a shorter jump

    Rigidbody rb; //reference rigidbody

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); //get the rigidbody
    }

    void FixedUpdate()
    {
        //if the vertical motion is less than zero, or falling, then increase the gravity
        if(rb.velocity.y < 0)
        {
            //only dealing with the y axis. the fallMultiplier - 1 is accounting for the normal gravity that is already
            //applied by the physics system
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //if vertical motion is greater than zero, or jumping, and the jump button is not still
        //being held, then go ahead and apply the lowJumpMultiplier, to make for a smaller jump
        //compared to if the button is held longer
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
