using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float ShakeDuration = 1f;          // Time the Camera Shake effect will last
    public float ShakeAmplitude = 6f;         // Cinemachine Noise Profile Parameter
    public float ShakeFrequency = 2.0f;         // Cinemachine Noise Profile Parameter
    
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    
    public void Shake(float duration = 1, float magnitude = 1)
    {
        if (duration == 1) duration = ShakeDuration;
        StartCoroutine(ShakeCamera(duration, magnitude));
    }
    
    public IEnumerator ShakeCamera(float duration, float magnitude)
    {
//        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude * magnitude;
            virtualCameraNoise.m_FrequencyGain = ShakeFrequency;
//            float x = Random.Range(-1f, 1f) * magnitude;
//            float y = Random.Range(-1f, 1f) * magnitude;
            
//            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            
            yield return null;
        }
        
        virtualCameraNoise.m_AmplitudeGain = 0;
        virtualCameraNoise.m_FrequencyGain = 0;

//        transform.localPosition = originalPos;
    } 
    
    // Use this for initialization
    void Start()
    {
        // Get Virtual Camera Noise Profile
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

}
