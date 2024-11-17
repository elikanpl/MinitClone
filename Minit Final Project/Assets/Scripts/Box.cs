using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update


    bool isCurrentlyColliding = false;

    public GameObject player;

    string direction = "helnbnjp"; 
    float boxMoveSpeed; 


    void OnCollisionEnter2D(Collision2D col)
    {
        isCurrentlyColliding = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        isCurrentlyColliding = false;
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = new Vector3(0, 0, 0);
        direction = GameObject.Find("Player").GetComponent<Player>().direction;
        boxMoveSpeed = GameObject.Find("Player").GetComponent<Player>().moveSpeed;

        if (isCurrentlyColliding)
        {
           

            if (direction == "right")
            {
                vel += new Vector3(boxMoveSpeed, 0, 0);
                Debug.Log("right");
            }
            if (direction == "left")
            {
                vel += new Vector3(-boxMoveSpeed, 0, 0);
                Debug.Log("left");
            }
            if (direction == "up")
            {
                vel += new Vector3(0, boxMoveSpeed, 0);
                Debug.Log("up");
            }
            if (direction == "down")
            {
                vel += new Vector3(0, -boxMoveSpeed, 0);
                Debug.Log("down");

            }
        }
        this.transform.position += vel;
        
        Debug.Log(direction.ToString());

    }
   
    
}
