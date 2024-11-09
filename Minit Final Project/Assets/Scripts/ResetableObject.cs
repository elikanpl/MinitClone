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
        transform.position = start;
    }
}
