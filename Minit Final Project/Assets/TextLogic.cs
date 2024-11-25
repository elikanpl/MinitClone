using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
