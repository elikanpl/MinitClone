using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : ResetableObject
{
    private SpriteRenderer sprRenderer;
    private Collider2D colliderComponent;
    public AudioSource sound;
    // Start is called before the first frame update

    public ParticleSystem leaves;
    void Start()
    {
        sprRenderer = this.GetComponent<SpriteRenderer>();
        colliderComponent = this.GetComponent<Collider2D>();
        sound = this.GetComponent<AudioSource>();
        start = transform.position;
        ResetManager.addTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deactivate()
    {
        if(sound != null) sound.Play();
        sprRenderer.enabled = false;
        colliderComponent.enabled = false;
        if(leaves != null) leaves.Play();
    }

    public override void Reset()
    {
        base.Reset();
        sprRenderer.enabled = true;
        colliderComponent.enabled = true;
    }
}
