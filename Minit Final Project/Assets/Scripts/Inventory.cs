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
        
    }
    public void CollectKey()
    {
        print("Key obtained!");
        key = true;
    }

    public void CollectFlashlight()
    {
        print("Flashlight obtained!");
        flashlight = true;
    }

    public void CollectCoffee()
    {
        if (Sword.reference.crabsDestroyed >= 5 && !coffee)
        {
            // Need to modify to get from NPC
            print("Coffee obtained!");
            coffee = true;
        }
    }

    private void CollectionScreen()
    {
        
    }
}
