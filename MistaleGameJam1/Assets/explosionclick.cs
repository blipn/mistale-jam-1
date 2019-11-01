using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionclick : MonoBehaviour
{
    public Obstacle Obstacle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Obstacle.Hit();
            //StartCoroutine(CameraShake.Shake(.15f, .4f));
        }
    }
}
