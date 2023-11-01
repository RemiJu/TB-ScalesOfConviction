using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Vector3 offset;
    public float smomothSpeed = 5f;

    void Start()
    {
        Vector3 deiredPosition = target1.position + offset;
    }

    void LateUpdate()
    {

        if (StatManager.Instance.playerTurn == true)
        {
            Vector3 deiredPosition = target1.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, deiredPosition, smomothSpeed);
            transform.position = smoothedPosition;
        }

        else if (StatManager.Instance.playerTurn == false)
        {
            Vector3 deiredPosition = target2.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, deiredPosition, smomothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
