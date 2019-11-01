using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
     
    [SerializeField] ParticleSystem explosionParticles;
    private bool hasPlayed;
    public int life = 2;
    
    IEnumerator uDed()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

    public void Hit()
    {
        life -= 1;
        //CameraManager.Instance.CameraShake.Shake();
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
