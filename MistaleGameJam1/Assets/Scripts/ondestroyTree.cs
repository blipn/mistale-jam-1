﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ondestroyTree : treeController
{
    public GameObject ameliaDead;
    
    override protected void Die()
    {
        PlayerPrefs.SetInt("tutorialDone", 1);
        ameliaDead.SetActive(true);
        _animator.SetBool("isFalling", true);
        StartCoroutine(uDed(1.5f));
    }
}
