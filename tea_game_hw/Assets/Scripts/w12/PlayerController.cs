using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //FROM CLASS, NOT USING IN THIS BUILD
    [SerializeField] float moveSpeed = 20f;

    Vector3 getInput;

    //called once per frame
    private void Update()
    {
        getInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        print(getInput);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = getInput * moveSpeed;

        Vector3 lookPos = new Vector3
        (
            transform.position.x + GetComponent<Rigidbody>().velocity.x,
            transform.position.y,
            transform.position.z + GetComponent<Rigidbody>().velocity.z
        );
        transform.LookAt(lookPos);
    }
}
