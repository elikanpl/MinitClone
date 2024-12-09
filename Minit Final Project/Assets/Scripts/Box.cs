using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update


    bool isCurrentlyColliding = false;

    public GameObject player;

    public AudioSource pushSound;
    private Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D col)
    {
        isCurrentlyColliding = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        isCurrentlyColliding = false;
    }

    void Awake()
    {
        pushSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.reference.coffee)
        {
            if (isCurrentlyColliding)
            {
                rb.isKinematic = false;
                if (!pushSound.isPlaying)
                {
                    pushSound.Play();
                }
            }
            else
            {
                pushSound.Stop();
            }
        }
    }
   
    
}
