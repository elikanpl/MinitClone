using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private Player player;
    private Image image;

    public Sprite twoLives;
    public Sprite oneLife;
    public Sprite zeroLives;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(image != null)
        {
            if (player.lives == 2)
            {
                image.sprite = twoLives;
            }
            if (player.lives == 1)
            {
                image.sprite = oneLife;
            }
            if (player.lives <= 0)
            {
                image.sprite = zeroLives;
            }
        }
    }
}
