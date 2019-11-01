using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int life = 2;
    
    public void Hit()
    {
        life -= 1;
        CameraManager.Instance.CameraShake.Shake(0.2f, 0.1f);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
