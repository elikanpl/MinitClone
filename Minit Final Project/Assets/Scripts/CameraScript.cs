using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
            player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x - transform.position.x > 10)
        {
            transform.position += transform.right*20;
        }
         if(player.transform.position.x - transform.position.x < -10)
        {
            transform.position -= transform.right*20;
        }
         if(player.transform.position.y - transform.position.y > 7.5)
        {
            transform.position += transform.up*15;
        }
         if(player.transform.position.y - transform.position.y < -7.5)
        {
            transform.position -= transform.up*15;
        }

    }
}
