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
    
    public void ZoomWithSlowdown(Transform targetPosition, Vector3 offset, float zoom = 10f, float duration = 0.5f)
    {
        StartCoroutine(zoomCamera(targetPosition, offset, zoom, duration));
    }
    
    private IEnumerator zoomCamera(Transform targetPosition, Vector3 offset,float zoom, float duration)
    {
        Camera camera = Camera.current;
        float originalZoom = camera.orthographicSize;
        Transform originalPosition = camera.transform;
        
        camera.transform.position = targetPosition.position + offset;
        

        Time.timeScale = 0.1f;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            if (Time.timeScale < 1f)
                Time.timeScale += .1f;
            if (camera.orthographicSize >= 10f)
                camera.orthographicSize = camera.orthographicSize -= .05f ;
//            //TODO SLOW BRACKEYS 
//            transform.localRotation = Quaternion.Lerp(originalRotation, targetRotation, Time.deltaTime * duration);
            elapsed += Time.deltaTime;
            
            yield return new WaitForSeconds(0.02f);
        }

        camera.transform.position = originalPosition.position;
        camera.orthographicSize = originalZoom;

    }
}

