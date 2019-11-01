using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHP : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticles;
    private bool amDed;
    private Animator animator;
    [SerializeField] GameObject deathScreen;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        DeathDetector.isPlayerDed = true;
        Destroy(gameObject);
    }

    private void uDed()
    {
        if (amDed)
            return;
        amDed = true;
        explosionParticles.Play();
        Instantiate(deathScreen);
        StartCoroutine(Death());
        //GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy")  && !animator.GetBool("IsAttacking")) || collision.CompareTag("BorderCamera"))
        {
            uDed();
        }
    }
}
