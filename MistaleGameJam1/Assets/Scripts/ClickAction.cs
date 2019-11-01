using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Obstacle Obstacle;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Obstacle.Hit();
//            StartCoroutine(CameraShake.Shake(.15f, .4f));
        }
    }
}
