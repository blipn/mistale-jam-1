using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int life = 2;
    public float intensityShake = 1f;
    public float durationShake = 0.1f;
    public void Hit()
    {
        life -= 1;
        CameraManager.Instance.CameraShake.Shake(durationShake, intensityShake);
        if (life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //TODO : Ajouter les effets d'explosion
        Destroy(gameObject);
        
    }
}
