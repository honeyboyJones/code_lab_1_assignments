using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if theres a situation where two scripts are the same name, namespace prevents conflict
namespace MathUtil
{
    public class Util : MonoBehaviour
    {
        public static bool CanSeeObj(GameObject destination, GameObject origin, float range)
        {
            //gets the direction between two points
            Vector3 dir = Vector3.Normalize(destination.transform.position - origin.transform.position);
            
            //angle of the line from the face of the NPC, higher is closer to center, lower is behind
            float angleDist = Vector3.Dot(origin.transform.forward, dir);

            Debug.DrawRay(origin.transform.position, origin.transform.forward * 10, Color.red);
            Debug.DrawRay(origin.transform.position, dir * 10, Color.cyan);

            if(angleDist > range)
            {
                return true;
            }
            else
            return false;
        }

        public static Vector3 ObjSide(GameObject destination, GameObject origin)
        {
            Vector3 dir = Vector3.Normalize(destination.transform.position - origin.transform.position);
            Vector3 crossProd = Vector3.Cross(origin.transform.forward, dir);
            //print(crossProd);

            if(crossProd.y < 0)
            {
                //print(destination.name + " IS LEFT OF " + origin.name);
            }
            else
            {
                //print(destination.name + " IS RIGHT OF " + origin.name);
            }
            return crossProd;
        }
    }
}

