using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public NPCBehaviour behaviour;
    //public Vector3 chaseTarget; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            behaviour.chasing = true;
        }
    }

    /**private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            behaviour.chasing = false;
        }
    }**/
}
