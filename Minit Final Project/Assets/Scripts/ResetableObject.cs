using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetableObject : MonoBehaviour
{
    protected Vector3 start;
    void Start()
    {
        start = transform.position;
        ResetManager.addTo(this);
    }
    public virtual void Reset()
    {
        transform.position = start;
    }
}
