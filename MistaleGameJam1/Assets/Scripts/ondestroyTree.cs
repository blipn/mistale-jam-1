﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ondestroyTree : MonoBehaviour
{
    public GameObject ameliaDead;

    private void OnDestroy()
    {
        ameliaDead.SetActive(true);
    }
}