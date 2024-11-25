using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : ResetableObject
{
    private SpriteRenderer sprRenderer;
    private Collider2D colliderComponent;
    // Start is called before the first frame update
    void Start()
    {
        sprRenderer = this.GetComponent<SpriteRenderer>();
        colliderComponent = this.GetComponent<Collider2D>();
        start = transform.position;
        ResetManager.addTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deactivate()
    {
        sprRenderer.enabled = false;
        colliderComponent.enabled = false;
    }

    public override void Reset()
    {
        base.Reset();
        sprRenderer.enabled = true;
        colliderComponent.enabled = true;
    }
}
