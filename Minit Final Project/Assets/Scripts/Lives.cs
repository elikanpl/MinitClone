using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    private Player player;
    private SpriteRenderer spriteRenderer;
    private Camera cam;

    public Sprite twoLives;
    public Sprite oneLife;
    public Sprite zeroLives;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = cam.ViewportToWorldPoint(position);
        if (player.lives == 2)
        {
            spriteRenderer.sprite = twoLives;
        }
        if (player.lives == 1)
        {
            spriteRenderer.sprite = oneLife;
        }
        if (player.lives <= 0)
        {
            spriteRenderer.sprite = zeroLives;
        }

    }
}
