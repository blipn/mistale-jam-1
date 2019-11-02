using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //Il doit faire des dégâts au joueur, il doit avoir des mouvements propres, w/ rigidbody et tout le tralala

    public float intensityShake = 1.5f;
    public float durationShake = 0.1f;
    
    [SerializeField] ParticleSystem explosionParticles;
    private float life = 1;

    IEnumerator uDed()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

    public void Hit()
    {
        if(gameObject.tag != "BorderCamera")
        {
            life -= 1;
            //CameraManager.Instance.CameraShake.Shake();
            if (life <= 0)
            {
                Die();
            }
        }        
    }

    void Die()
    {
        CameraManager.Instance.CameraJuicy.ZoomWithSlowdown(transform, new Vector3(0,0,0));
        CameraManager.Instance.CameraShake.Shake(durationShake, intensityShake);
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        explosionParticles.Play();
        StartCoroutine(uDed());
    }
    
}

