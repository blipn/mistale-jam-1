using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHP : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

    private void uDed()
    {
        explosionParticles.Play();
        StartCoroutine(Death());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
