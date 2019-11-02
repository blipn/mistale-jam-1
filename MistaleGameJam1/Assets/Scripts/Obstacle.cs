using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
     
    [SerializeField] ParticleSystem explosionParticles;
    private bool isDed;
    public int life = 2;

    IEnumerator uDed()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
    


    public float intensityShake = 1f;
    public float durationShake = 0.1f;
   
    public void Hit()
    {
        if (isDed)
        {
            return;
        }
        life -= 1;
        
        if (CameraManager.Instance != null)
        {
            CameraManager.Instance.CameraShake.Shake(durationShake, intensityShake);
            
        }

        if (life <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        isDed = true;
        explosionParticles.Play();
//        CameraManager.Instance.CameraJuicy.rotation(-3f, .2f);
        StartCoroutine(uDed());
        
    }
}
