using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdMovement : MonoBehaviour
{
    public float speed = 10f;

    public bool scrollEnabled = true;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (scrollEnabled)
        {
            transform.position += new Vector3(1 * speed * Time.deltaTime, 0,0);
        }
    }
}
