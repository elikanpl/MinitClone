using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Collider2D collider2d;
    private Player player;
    private Collider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            player.lives--;
            //Invincibility frames - add flashing?
            playerCollider = collision.collider;
            playerCollider.enabled = false;
            Invoke("IFramesEnd", 1);
        }
    }

    private void IFramesEnd()
    {
        playerCollider.enabled = true;
    }
}
