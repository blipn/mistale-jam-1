using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int life = 2;
    
    public void Hit()
    {
        life -= 1;
        CameraManager.Instance.CameraShake.Shake();
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
