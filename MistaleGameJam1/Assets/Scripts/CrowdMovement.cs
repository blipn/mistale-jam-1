using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdMovement : MonoBehaviour
{
    public float baseSpeed = 40f;
    public float beforeBaseSpeedRate = 0.3f;
    public float increaseSpeedRate = 0.5f;
    public float speed = 0f;

    private void Start()
    {
        StartCoroutine(toBaseSpeed());
        StartCoroutine(SpeedManager());
    }

    public bool scrollEnabled = true;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (scrollEnabled)
        {
            transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
        }
    }

    IEnumerator SpeedManager()
    {
        yield return new WaitForSeconds(5);
        speed += increaseSpeedRate;
        StartCoroutine(SpeedManager());
    }
    
    IEnumerator toBaseSpeed()
    {
        yield return new WaitForSeconds(0.1f);
        speed += beforeBaseSpeedRate;
        if (speed < baseSpeed)
        {
            StartCoroutine(toBaseSpeed());
        }
    }
}