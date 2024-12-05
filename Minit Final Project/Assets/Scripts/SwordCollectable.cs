using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            print("Press space to use sword");
            Inventory.reference.sword = true;
            Inventory.reference.equipped = "sword";
            ResetManager.reference.TimerActive = true;
            Destroy(gameObject);
        }
    }
}
