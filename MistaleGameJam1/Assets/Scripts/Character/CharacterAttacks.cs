using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttacks : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            collision.GetComponent<Obstacle>().Hit();
        }

        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyBehavior>().Hit();
        }
    }
}
