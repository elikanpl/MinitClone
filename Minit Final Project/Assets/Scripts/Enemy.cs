using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Collider2D collider2d;
    private Player player;
    private Collider2D playerCollider;
    public float bounceSpeed;
    private Vector3 bounce;
    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
        bounceSpeed = 0.5f;
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
            //Invincibility frames
            playerCollider = collision.collider;
            playerCollider.enabled = false;
            player.sleep = true;
            //bounce the player back a bit
            bounce = player.gameObject.transform.position - this.transform.position;
            bounce = bounce.normalized;
            bounce *= bounceSpeed;
            player.gameObject.transform.position += bounce;
            InvokeRepeating("Flicker", 0.1f, 0.1f);
            Invoke("Unfreeze", 0.2f);
            Invoke("IFramesEnd", 1.2f);
        }
    }

    private void IFramesEnd()
    {
        if(player.lives > 0) playerCollider.enabled = true;
        CancelInvoke();
    }

    private void Unfreeze()
    {
        player.sleep = false;
    }

    // Flicker the sprite when damaged
    private void Flicker()
    {
        SpriteRenderer sprRenderer = player.gameObject.GetComponent<SpriteRenderer>();
        if (sprRenderer != null)
        {
            sprRenderer.enabled = !sprRenderer.enabled;
        }
    }

}
