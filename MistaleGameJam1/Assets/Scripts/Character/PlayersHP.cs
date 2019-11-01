using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHP : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticles;
    private bool amDed;

    IEnumerator Death()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

    private void uDed()
    {
        if (amDed)
            return;
        explosionParticles.Play();
        Debug.Log("BOOM !!");
        StartCoroutine(Death());
        //GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("i ma touché ;(");
            uDed();
        }
    }
}
