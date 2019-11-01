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
        life -= 1;
        //CameraManager.Instance.CameraShake.Shake();
        if (life <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        explosionParticles.Play();
        StartCoroutine(uDed());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}

