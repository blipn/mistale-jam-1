using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttacks : MonoBehaviour
{
    public AudioSource attackSoundVoid;
    public AudioSource attackSoundEnemy;
    public AudioSource attackSoundObstacle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            attackSoundVoid.mute = true;
            attackSoundObstacle.Play();
            collision.GetComponent<Obstacle>().Hit();
        }
        else if(collision.tag == "Enemy")
        {
            attackSoundVoid.mute = true;
            attackSoundEnemy.Play();
            collision.GetComponent<EnemyBehavior>().Hit();
        }
    }
}
