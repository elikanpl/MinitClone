using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseDoor : MonoBehaviour
{
    private Collider2D col;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        col = this.GetComponent<Collider2D>();
        sound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Inventory.reference.key)
        {
            sound.Play();
            col.enabled = false;
        }
    }
}
