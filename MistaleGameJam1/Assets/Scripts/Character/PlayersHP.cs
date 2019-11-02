using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHP : MonoBehaviour
{
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
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    private void uDed()
    {
        if (amDed)
            return;
        amDed = true;
        m_spriteCharacter.enabled = false;
        explosionParticles.Play();
        StartCoroutine(Death());
        GameManager.Instance.GameOver();
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
