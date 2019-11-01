using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShakeClassic : MonoBehaviour
{
   
    public void Shake(float duration = 0.1f, float magnitude = 1f)
    {
        StartCoroutine(ShakeCamera(duration, magnitude));
    }
    
    public IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {

            float x = Random.Range(-1f, 1f) * magnitude * 0.1f;
            float y = Random.Range(-1f, 1f) * magnitude * 0.1f;
            
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            
            yield return null;
        }

       transform.localPosition = originalPos;
    }
}