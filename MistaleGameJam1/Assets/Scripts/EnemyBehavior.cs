using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //Il doit faire des dégâts au joueur, il doit avoir des mouvements propres, w/ rigidbody et tout le tralala

    [SerializeField] ParticleSystem explosionParticles;
    private float life = 1;

    IEnumerator uDed()
    {
        yield return new WaitForSeconds(.1f);
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
        explosionParticles.Play();
        StartCoroutine(uDed());
    }
    
}

