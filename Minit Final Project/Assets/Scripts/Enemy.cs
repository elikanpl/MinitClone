using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Collider2D collider2d;
    private Player player;
    private Collider2D playerCollider;
    public AudioSource sound;
    
    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if (sound != null) sound.Play();
            player.GetHit(gameObject);
        }
    }

}
