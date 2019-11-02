using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    
    public float slowdownFactor = 0.1f;
    public float slowdownLength = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


//    public void BulletTime()
//    {
//        Time.timeScale = slowdownFactor;
//        Time.fixedDeltaTime = Time.timeScale * .02f;
//    }
    
    public void BulletTime()
    {
        StartCoroutine(BullletTimeCoroutine());
    }

    private void Update()
    {
        // MODIFY THE PITCH TO MAKE IT SLOWER
        
    }
    
    private IEnumerator BullletTimeCoroutine()
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < slowdownLength)
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

            elapsed += Time.deltaTime;
            
            yield return new WaitForSeconds(0.05f);
        }

        transform.localPosition = originalPos;
    }
}
