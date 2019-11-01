using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdMovement : MonoBehaviour
{
    public float speed = 10f;
  
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(1 * speed * Time.deltaTime, 0,0);
    }
}
