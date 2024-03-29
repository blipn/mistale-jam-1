﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;
    
    private void FixedUpdate()
    {
        
        Vector3 desiredPosition = offset +  new Vector3(target.position.x , 0, 0);
        desiredPosition.z = -100;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
    }
}
