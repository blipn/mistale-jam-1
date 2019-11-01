using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHP : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticles;
    private bool amDed;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void uDed()
    {
        if (amDed)
            return;
        amDed = true;
        explosionParticles.Play();
        StartCoroutine(Death());
        //GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !animator.GetBool("IsAttacking"))
        {
            uDed();
        }
    }
}
