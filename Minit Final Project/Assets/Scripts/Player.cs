using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public string direction;
    public bool sleep;

    private bool isFacingRight = true;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        sleep = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
      
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

                if (isFacingRight == false) {
                    spriteRenderer.flipX = false;
                    isFacingRight = true;

                }

            }
            if (Input.GetKey(KeyCode.A))
            {
                vel += new Vector3(-moveSpeed, 0, 0);
                direction = "left";

                if (isFacingRight == true)
                {
                    spriteRenderer.flipX = true;
                    isFacingRight = false;
                }
                    
               


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
