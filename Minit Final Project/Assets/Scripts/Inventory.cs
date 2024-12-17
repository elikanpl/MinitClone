using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public Sprite coffeeSpr;
    public Sprite swordSpr;
    public Sprite keySpr;
    public Sprite flashlightSpr;
    private GameObject item;
    private SpriteRenderer itemSprite;
    private GameObject currItem;
    private Vector3 position;
    public float spaceAboveHead;


    public DialogueTrigger CoffeeChange;
    public AudioSource itemCollectSound;

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
        item = GameObject.Find("Item");
        if (item != null)
        {
            itemSprite = item.GetComponent<SpriteRenderer>();
            itemSprite.enabled = false;
        }
        itemCollectSound = GetComponent<AudioSource>();
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
        itemSprite.sprite = swordSpr;
        CollectionScreen();
        sword = true;
        gotSword = true;
        
    }
    public void CollectKey()
    {
        TextManager.reference.DisplayItemText("Got the key!");
        itemSprite.sprite = keySpr;
        CollectionScreen();
        print("Key obtained!");
        key = true;
    }

    public void CollectFlashlight()
    {
        itemSprite.sprite = flashlightSpr;
        TextManager.reference.DisplayItemText("Got the flashlight!");
        CollectionScreen();
        flashlight = true;
    }

    public void CollectCoffee()
    {
        if (Sword.reference.crabsDestroyed >= 5 && !coffee)
        {
            TextManager.reference.DisplayItemText("Got the coffee!");
            itemSprite.sprite = coffeeSpr;
            CollectionScreen();
            coffee = true;
            CoffeeChange.text = "SO GLAD THOSE CRABS ARE GONE";
        }
        
    }

    private void CollectionScreen()
    {
        // Display collected item above player's head
        if(item != null)
        {
            position = player.transform.position;
            position.y += spaceAboveHead;
            item.transform.position = position;
            itemSprite.enabled = true;
        }
        
        if(itemCollectSound != null) itemCollectSound.Play();
        Sword.reference.disabled = true;
        player.sleep = true;
        collectionScreen = true;
        sprRenderer.enabled = true;
        Vector3 camPos = Camera.main.transform.position;
        this.transform.position = new Vector3(camPos.x, camPos.y, this.transform.position.z);
        ResetManager.reference.TimerActive = false;
        TextManager.reference.DisplayControls("Press Space to Continue");
    }

    private void CollectionScreenEnd()
    {
        if(itemSprite!= null) itemSprite.enabled = false;
        collectionScreen = false;
        player.sleep = false;
        sprRenderer.enabled = false;
        ResetManager.reference.TimerActive = true;
        TextManager.reference.HideItemText();
        TextManager.reference.HideControls();
        if(gotSword)
        {
            TextManager.reference.DisplayControls("Press Space to Use Sword");
            ResetManager.reference.TimerStart();
            player.EquipSword();
            gotSword = false;
        }
        Invoke("UnfreezeSword", 0.1f);
    }

    private void UnfreezeSword()
    {
        Sword.reference.disabled = false;
    }
}
