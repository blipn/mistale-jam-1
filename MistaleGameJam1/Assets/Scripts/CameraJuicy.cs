using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJuicy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
  
    //TODO ZOOM
    //TODO ROTATION
    
    
    public void rotation(float rotation = -3f, float duration = 0.3f)
    {
        StartCoroutine(RotateCamera(rotation, duration));
    }
    
    private IEnumerator RotateCamera(float rotation, float duration)
    {
        Quaternion originalRotation = transform.localRotation;
        Quaternion targetRotation = originalRotation * new Quaternion(0f,0f,rotation, 0f);
        
        float elapsed = 0f;

        while (elapsed < duration)
        {
            //TODO SLOW BRACKEYS 
            transform.localRotation = Quaternion.Lerp(originalRotation, targetRotation, Time.deltaTime * duration);
            elapsed += Time.deltaTime;
            
            yield return null;
        }

        transform.localRotation = originalRotation;
    }
}
