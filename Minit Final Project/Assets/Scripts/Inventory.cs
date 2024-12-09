using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory reference;
    public float inventoryScreenTime;
    public bool sword;
    public bool coffee;
    public bool flashlight;
    public bool key;
    private SpriteRenderer sprRenderer;
    private Player player;
    private bool collectionScreen;
    private bool gotSword;

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
        sprRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(collectionScreen)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                CollectionScreenEnd();
            }
        }
    }

    public void CollectSword()
    {
        TextManager.reference.DisplayItemText("Got the sword!");
        CollectionScreen();
        sword = true;
        gotSword = true;
        ResetManager.reference.TimerStart();
    }
    public void CollectKey()
    {
        TextManager.reference.DisplayItemText("Got the key!");
        CollectionScreen();
        print("Key obtained!");
        key = true;
    }

    public void CollectFlashlight()
    {
        TextManager.reference.DisplayItemText("Got the flashlight!");
        CollectionScreen();
        flashlight = true;
    }

    public void CollectCoffee()
    {
        if (Sword.reference.crabsDestroyed >= 5 && !coffee)
        {
            TextManager.reference.DisplayItemText("Got the coffee!");
            CollectionScreen();
            coffee = true;
        }
    }

    private void CollectionScreen()
    {
        collectionScreen = true;
        sprRenderer.enabled = true;
        Vector3 camPos = Camera.main.transform.position;
        this.transform.position = new Vector3(camPos.x, camPos.y, this.transform.position.z);
        player.sleep = true;
        ResetManager.reference.TimerActive = false;
        TextManager.reference.DisplayControls("Press Space to Continue");
    }

    private void CollectionScreenEnd()
    {
        collectionScreen = false;
        player.sleep = false;
        sprRenderer.enabled = false;
        ResetManager.reference.TimerActive = true;
        TextManager.reference.HideItemText();
        TextManager.reference.HideControls();
        if(gotSword)
        {
            TextManager.reference.DisplayControls("Press Space to Use Sword");
            gotSword = false;
        }
    }

}
