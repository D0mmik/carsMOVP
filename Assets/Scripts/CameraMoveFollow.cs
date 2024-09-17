using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothingSpeed;
    public float smoothingSpeedRotation;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.), target.position, 10);
        transform.LookAt(target);

    }
}
