using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smomothSpeed = 5f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 deiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, deiredPosition, smomothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
