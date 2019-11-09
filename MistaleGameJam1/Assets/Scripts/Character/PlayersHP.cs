using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersHP : MonoBehaviour
{
    private float timeAfterDeath = 0.5f;
    [SerializeField] private ParticleSystem explosionParticles;
    private bool amDed;
    private Animator animator;

    private SpriteRenderer m_spriteCharacter;

    private void Start()
    {
        animator = GetComponent<Animator>();
        m_spriteCharacter = GetComponent<SpriteRenderer>();
        m_spriteCharacter.enabled = true;
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(timeAfterDeath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void uDed()
    {
        if (amDed)
            return;
        amDed = true;
        m_spriteCharacter.enabled = false;
        explosionParticles.Play();
        StartCoroutine(Death());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" && !animator.GetBool("IsAttacking")) || collision.gameObject.tag == "BorderCamera")
        {
            uDed();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BorderCamera")
        {
            uDed();
        }
    }
}
