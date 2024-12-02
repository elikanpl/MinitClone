using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessObject : MonoBehaviour
{
    public Sprite Dark,Darker,Darkest,Black;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Black;
    }

    public void noDark()
    {
        spriteRenderer.sprite = null;
    }
    public void setDark()
    {
        spriteRenderer.sprite = Dark;
    }
    public void setDarker()
    {
        spriteRenderer.sprite = Darker;
    }
    public void setDarkest()
    {
        spriteRenderer.sprite = Darkest;
    }
    public void setBlack()
    {
        spriteRenderer.sprite = Black;
    }
}
