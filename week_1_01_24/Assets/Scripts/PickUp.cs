using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    Vector3 objectPos; //transform of the object
    float distance; //for setting the distance an item can be picked up from

    public float throwForce = 600f; //force to throw object compared to its mass
    public bool canHold = true; //if an item can be picked up
    public GameObject item; //item to pick up
    public GameObject tempParent; //temporary parent (set as Destination)
    public bool isHolding = false; //if the item is being held currently
    public Transform theDest; //the transform of the temp parent

    //called once per frame
    void Update()
    {
        //sets the distance of the item, checking the distance between the item and the 
        //temp parent (Destination) which is in front of the player's camera
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);

        //if the distance is less than 5
        if(distance >= 5f)
        {
            //sets holding to false, either dropping the item if it's stuck behind something,
            //or not allowing the item to be picked up in the first place
            isHolding = false;
        }

        //check if player is holding an item
        if(isHolding == true)
        {
            //sets the velocity and angular velocity to zero, allowing the item to be stationary
            //while being held, but still able to hit walls etc
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            //sets the parent item to the temp parent (Destination) so the item moves in front of
            //the players field of view
            item.transform.SetParent(tempParent.transform);

            //turns off gravity for the item and turns on detect collisions
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;

            item.transform.position = theDest.position;

            //if the item is being held and the left mouse button is pressed
            if(Input.GetMouseButtonDown(0))
            {
                //takes the item's rigidbody and adds force in the direction of forward from the temp
                //parent's position * the throw force
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;

                //saves the item's position from the position it is in, unparents item from the temp
                //parent, turns gravity back on, and uses the saved position to set the item's position
                objectPos = item.transform.position;
                item.transform.SetParent(null);
                item.GetComponent<Rigidbody>().useGravity = true;
                item.transform.position = objectPos;
            }
            //if the item is being held and the space bar is pressed
            if(Input.GetKeyDown("space"))
            {
                //sets holding to false, dropping the item
                isHolding = false;

                //saves the item's position from the position it is in, unparents item from the temp
                //parent, turns gravity back on, and uses the saved position to set the item's position
                objectPos = item.transform.position;
                item.transform.SetParent(null);
                item.GetComponent<Rigidbody>().useGravity = true;
                item.transform.position = objectPos;
            }
        }
    }

    //if the player mouse (current view) is over an item
    void OnMouseOver()
    {
        //if the player presses the E key
        if(Input.GetKeyDown(KeyCode.E))
        {
            //sets isHolding to true
            isHolding = true;
        }
        else
        {
            //otherwise doesn't
            isHolding = false;
        }
        
    }
}
