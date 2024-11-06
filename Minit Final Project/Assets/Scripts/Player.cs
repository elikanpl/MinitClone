using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            vel += new Vector3(moveSpeed, 0, 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
            vel += new Vector3(-moveSpeed, 0, 0);

        }
        if (Input.GetKey(KeyCode.W))
        {
            vel += new Vector3(0, moveSpeed, 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
            vel += new Vector3(0, -moveSpeed, 0);

        }

        this.transform.position += vel;
    }
}
