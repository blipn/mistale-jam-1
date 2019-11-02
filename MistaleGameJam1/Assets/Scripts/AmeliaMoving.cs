using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeliaMoving : MonoBehaviour
{
    public float speed;
    private float stoppingDistance = 15;
    private Transform player;
    private SpriteRenderer spr;
    private bool end;
    [SerializeField] ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = this.transform.position;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "death")
        {
            spr.flipX = true;
            end = true;
        }

        if (collision.gameObject.tag == "death2" && !end)
        {
            explosion.Play();
            SaveLoad.Save("Proto");
            GameManager.Instance.button_Play();
        }
        

        
    }
}
