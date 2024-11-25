using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory reference;
    public bool sword;
    public bool coffee;
    public bool flashlight;
    public bool key;
    public string equipped;

    private void Awake()
    {
        reference = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sword = false;
        coffee = false;
        flashlight = false;
        key = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Sword.reference.crabsDestroyed >= 5)
        {
            //Modify to only get once entering the bar
            coffee = true;
        }
    }
}
