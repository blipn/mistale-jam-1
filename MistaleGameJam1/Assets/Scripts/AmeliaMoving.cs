using System;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ameliaVulnerable")
        {
            gameObject.tag = "Obstacle";
        }
    }

    private void OnDestroy()
    {
        SaveLoad.Save("Proto");
        GameManager.Instance.button_Play();
    }
}
