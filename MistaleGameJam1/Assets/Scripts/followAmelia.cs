﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followAmelia : MonoBehaviour
{
    public Transform Amelia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Amelia.position;
    }
}
