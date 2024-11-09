using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public string direction;
    public bool sleep;

    void Start()
    {
        sleep = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = new Vector3(0, 0, 0);

        if (!sleep)
        {
            if (Input.GetKey(KeyCode.D))
            {
                vel += new Vector3(moveSpeed, 0, 0);
                direction = "right";

            }
            if (Input.GetKey(KeyCode.A))
            {
                vel += new Vector3(-moveSpeed, 0, 0);
                direction = "left";

            }
            if (Input.GetKey(KeyCode.W))
            {
                vel += new Vector3(0, moveSpeed, 0);
                direction = "up";

            }
            if (Input.GetKey(KeyCode.S))
            {
                vel += new Vector3(0, -moveSpeed, 0);
                direction = "down";

            }
        }
        this.transform.position += vel;
    }
}
