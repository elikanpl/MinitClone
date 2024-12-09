using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class stairTP : MonoBehaviour
{
    public Vector3 TargetSpot;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.position = TargetSpot;
    }
}
