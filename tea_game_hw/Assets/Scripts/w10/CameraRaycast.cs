using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    //references
    public float sphereRadius = 0.5f;
    public float zOffset = 10f; //not using

    GameObject heldObj; //not using
    Vector3 objOriginalPos; //not using
    
    //called once per frame
    void Update()
    {
        Vector3 eyePosition = transform.position; //position of the center of the camera
        Vector3 mousePos = Input.mousePosition; //position of the mouse in pixel coordinates

        mousePos.z = Camera.main.nearClipPlane; //set the z position of the mouse to the near clip plane

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos); //turns the mouse position into world position

        //get the direction the camera is facing
        //normalize keeps the direction but makes the legnth 1.0
        //(1,1) = upper right, (1,-1) = lower right
        //(-1,1) = upper left, (-1,-1) = lower left
        Vector3 dir = mouseWorldPos - eyePosition;
        dir.Normalize();

        RaycastHit hitter = new RaycastHit(); //sends out a ray (line)

        Debug.DrawLine(eyePosition, dir*20f, Color.red); //tool to visualize the ray

        //if the ray hits something, get and print the name of that thing
        if(Physics.SphereCast(eyePosition, sphereRadius, dir, out hitter))
        {
            print("HIT SOMETHING");
            print(hitter.collider.gameObject.name);

            //if the ray hits something and the mouse button is pressed on an object tagged butt
            if(Input.GetMouseButton(0) && hitter.collider.gameObject.tag == "butt" && heldObj == null)
            {
                //print("CAN PICK UP");
                //PickUpObject(hitter.collider.gameObject);

                MuseumManager.instance.AddPoint(); //add a point on the museum manager

                GameObject.Destroy(hitter.transform.gameObject); //destroy the butt object (there may be a
                                                                 //better way to prevent infinite points but idk)
            }
        }

        // if(Input.GetMouseButton(1) && heldObj != null)
        // {
        //     DropObject();
        // }
    }

    // void PickUpObject(GameObject obj)
    // {
    //     heldObj = obj;
    //     objOriginalPos = obj.transform.position;

    //     obj.transform.SetParent(gameObject.transform);

    //     Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + zOffset);

    //     obj.transform.position = newPos;
    // }

    // void DropObject()
    // {
    //     heldObj.transform.SetParent(null);
    //     heldObj.transform.position = objOriginalPos;

    //     objOriginalPos = Vector3.zero;
    //     heldObj = null;
    // }
}
