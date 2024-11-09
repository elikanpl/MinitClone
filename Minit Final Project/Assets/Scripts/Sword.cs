using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private GameObject player;
    private Player playerScript;
    private SpriteRenderer spriteRenderer;
    public float distance;
    private Vector3 rotation;
    private bool rotated;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        rotation = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            playerScript.sleep = true;
            Invoke("Appear", 0.5f);
        }
        
    }

    //Need to add collision
    private void Appear()
    {
        spriteRenderer.enabled = true;
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        if (playerScript.direction == "right")
        {
            rotation.z = 0;
            newPos.x += distance;
        }
        if (playerScript.direction == "up")
        {
            rotation.z = 90;
            newPos.y += distance;
        }
        if (playerScript.direction == "down")
        {
            rotation.z = 90;
            newPos.y -= distance;
        }
        if (playerScript.direction == "left")
        {
            rotation.z = 0;
            newPos.x -= distance;
            
        }
        this.transform.position = newPos;
        gameObject.transform.Rotate(rotation, Space.World);
        Invoke("Disappear", 1);
    }

    private void Disappear()
    {
        gameObject.transform.rotation = Quaternion.identity;
        spriteRenderer.enabled = false;
        playerScript.sleep = false;
    }
}
