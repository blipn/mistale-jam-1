using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeController : Obstacle
{

    protected Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    override protected void Die()
    {
        _animator.SetBool("isFalling", true);
        StartCoroutine(uDed(1.5f));
    }
}
