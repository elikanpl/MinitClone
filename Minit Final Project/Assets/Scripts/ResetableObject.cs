using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetableObject : MonoBehaviour
{
    Vector3 start;
    void Start()
    {
        start = transform.position;
        ResetManager.addTo(this);
    }
    public void Reset()
    {
        if(this.GetComponent<SpriteRenderer>() != null)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (this.GetComponent<Collider2D>() != null)
        {
            this.GetComponent<Collider2D>().enabled = true;
        }
        transform.position = start;
    }
}
