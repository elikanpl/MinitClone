using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : ResetableObject
{
    public static Sword reference;
    public float distance;
    public float delay;
    public float duration;
    public int crabsDestroyed;

    private GameObject player;
    private Player playerScript;
    private SpriteRenderer spriteRenderer;
    private Collider2D colliderComponent;
    private Vector3 rotation;
    public bool disabled;
    

    private void Awake()
    {
        reference = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        colliderComponent = this.GetComponent<Collider2D>();
        spriteRenderer.enabled = false;
        rotation = new Vector3(0, 0, 0);
        ResetManager.addTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(Inventory.reference == null)
            return;
        if(Inventory.reference.sword && Input.GetKeyDown(KeyCode.Space) && 
            !playerScript.sleep && !playerScript.isDead && !disabled)
        {
            print("Sword");
            TextManager.reference.HideControls();
            playerScript.sleep = true;
            Invoke("Appear", delay);
        }
        
    }

    //Need to add collision
    private void Appear()
    {
        spriteRenderer.enabled = true;
        colliderComponent.enabled = true;
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        if (playerScript.direction == "right")
        {
            rotation.z = 270;
            newPos.x += distance;
        }
        if (playerScript.direction == "up")
        {
            rotation.z = 0;
            newPos.y += distance;
        }
        if (playerScript.direction == "down")
        {
            rotation.z = 180;
            newPos.y -= distance;
        }
        if (playerScript.direction == "left")
        {
            rotation.z = 90;
            newPos.x -= distance;
            
        }
        this.transform.position = newPos;
        gameObject.transform.Rotate(rotation, Space.World);
        Invoke("Disappear", duration);
    }

    private void Disappear()
    {
        gameObject.transform.rotation = Quaternion.identity;
        spriteRenderer.enabled = false;
        colliderComponent.enabled = false;
        playerScript.sleep = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyableObject destroyable = collision.gameObject.GetComponent<DestroyableObject>();
        if (destroyable != null)
        {
            if(collision.gameObject.GetComponent<Crab>() != null)
            {
                crabsDestroyed += 1;
            }
            destroyable.Deactivate();        
        }
    }

    public override void Reset()
    {
        crabsDestroyed = 0;
    }
}
