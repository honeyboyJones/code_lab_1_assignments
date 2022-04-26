using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigUtil : MonoBehaviour
{
    //references
    public float amplitude;
    public float frequency;
    public float offset;

    //called once per frame
    void Update()
    {
        //float x = Mathf.Cos(Time.time * frequency) * amplitude;
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        //float z = Mathf.Tan(Time.time * frequency) * amplitude;

        float x = transform.position.x;
        //float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3 (x, y + offset, z);
    }
}
