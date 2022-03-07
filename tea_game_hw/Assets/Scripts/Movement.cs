using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2f; //speed of movement
    public CharacterController controller; //references the character controller
    //public Rigidbody rigidbody;
    

    //called once per frame
    void Update()
    {
        //gathers built-in input as 1 or -1
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //transform.right takes the direction the player is facing and goes to the right
        //transform.forward takes the direction the player is facing and goes forward
        //this allows for local movement that changes based on the direction the player
        //is facing
        Vector3 move = transform.right * x + transform.forward * z;

        //uses character controller's move function using the Vector3 move * speed
        //* Time.deltaTime, making it framerate independant
        //controller.Move(move * speed * Time.deltaTime);
    }
}
