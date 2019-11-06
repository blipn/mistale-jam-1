using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpAnimationFollow : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(player.position.x, 3, 0);
    }

    private void OnAnimatorMove()
    {
        throw new NotImplementedException();
    }
}
