using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : MonoBehaviour
{
    public float walkSpeed = 2f; //speed of walking
    public float runSpeed = 4f; //speed of running
    public float groundAcceleration = 10f; //speed of movement while grounded
    public float jumpSpeed = 5f; //speed of jump

    Rigidbody rBody; //for gathering rigidbody
    Vector3 direction = Vector3.zero; //direction starts at zero

    public enum State //movement states
    {
        Walking,
        Running,
        Jumping
    }

    State currentState; //keeps track of the current state

    //state bools
    bool walking;
    bool running;
    bool jumping;
    bool canJump = true;
    bool isGrounded;

    //called at the beginning
    void Start()
    {
        //get the rigidbody
        rBody = GetComponent<Rigidbody>();
    }

    //if the player is colliding with the ground, set grounded to true
    void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }
    
    //called once per frame
    void Update()
    {
        print(currentState);

        //sets player direction
        direction = Direction();

        //in update, check for running and jumping independent of state
        running = (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0.9);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //jumping = true;
            Jump();
            //currentState = State.Jumping;
            TransitionState(State.Jumping);

            //no longer grounded, so cant jump again
            isGrounded = false;
        }
        else
        {
            TransitionState(State.Walking);
        }

        //if running, use runSpeed, otherwise use walkSpeed
        if(currentState == State.Walking)
        {
            Walk(direction, running ? runSpeed : walkSpeed, groundAcceleration);
        }
    }

    //transition state
    void TransitionState(State newState)
    {
        //set the new state to be the current state
        currentState = newState;
        switch (newState)
        {
            case State.Walking:
            Walk(direction, running ? runSpeed : walkSpeed, groundAcceleration);
            break;
            case State.Running:
            //do running
            break;
            case State.Jumping:
            Jump();
            break;
        }

        jumping = false;
    }

    private Vector3 Direction()
    {
        //gathers built-in input as 1 or -1
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //sets direction as new vector3 and TransformDirection transforms from local to world space
        Vector3 direction = new Vector3(x, 0, z);
        return rBody.transform.TransformDirection(direction);
    }

    //walking takes direction, speed, and acceleration
    void Walk(Vector3 wishDirection, float maxSpeed, float acceleration)
    {
        //if not walking and can jump, allow walking and jumping
        if(currentState != State.Walking && canJump)
        {
            currentState = State.Walking;
        }
        // if(jumping && canJump)
        // {
        //     Jump();
        // }

        //here is for getting desired direction with velocity
        else
        {
            //normalized vector keeps direction but its length is 1.0
            wishDirection = wishDirection.normalized;
            Vector3 speed = new Vector3(rBody.velocity.x, 0f, rBody.velocity.z);

            //magnitude returns the length of the vector
            if(speed.magnitude > maxSpeed) acceleration *= speed.magnitude / maxSpeed;
            Vector3 direction = wishDirection * maxSpeed - speed;

            //this part is confusing, i'll need to check back with it
            //direction is the normalized direction * acceleration
            //magnitude is the length of direction
            direction = direction.normalized * acceleration;
            float magnitude = direction.magnitude;
            direction = direction.normalized; //this one feels unnecessary
            direction *= magnitude;

            //finally, addforce to the rigidbody for movement
            rBody.AddForce(direction, ForceMode.Acceleration);
        }
    }

    //here is jumping
    void Jump()
    {
        //if walking and can jump
        if(currentState == State.Walking && canJump)
        {
            print("trying to jump");
            currentState = State.Jumping;
            
            //upforce is clamped to jumpspeed - velocity of y, with min being 0
            //and max being infinity (for safe measure)
            float upForce = Mathf.Clamp(jumpSpeed - rBody.velocity.y, 0, Mathf.Infinity);
            rBody.AddForce(new Vector3(0, upForce, 0), ForceMode.VelocityChange);

            //StartCoroutine(jumpCooldownCoroutine(.5f));
        }
    }

    //cooldown to prevent forever jumping, not going to use because it doesnt solve the problem
    // IEnumerator jumpCooldownCoroutine(float time)
    // {
    //     canJump = false;
    //     yield return new WaitForSeconds(time);
    //     canJump = true;
    // }
}