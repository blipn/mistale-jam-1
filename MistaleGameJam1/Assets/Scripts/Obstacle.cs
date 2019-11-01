﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
     
    [SerializeField] ParticleSystem explosionParticles;
    private bool hasPlayed;
    public int life = 2;

    public float intensityShake = 1f;
    public float durationShake = 0.1f;

    public void Hit()
    {
        life -= 1;
        CameraManager.Instance.CameraShake.Shake(durationShake, intensityShake);
    }

    IEnumerator uDed()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }



    public void Die()
    {
        explosionParticles.Play();
        StartCoroutine(uDed());
        
    }
}
