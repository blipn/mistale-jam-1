using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
     
    [SerializeField] ParticleSystem explosionParticles;
    private bool hasPlayed;
    public int life = 2;
<<<<<<< HEAD
    public float intensityShake = 1f;
    public float durationShake = 0.1f;
    public void Hit()
    {
        life -= 1;
        CameraManager.Instance.CameraShake.Shake(durationShake, intensityShake);
=======
    
    IEnumerator uDed()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

    public void Hit()
    {
        life -= 1;
        //CameraManager.Instance.CameraShake.Shake();
>>>>>>> 9fd1bc0ea877056604284909ce3fcbe7fbdb750d
        if (life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        explosionParticles.Play();
        StartCoroutine(uDed());
        
    }
}
