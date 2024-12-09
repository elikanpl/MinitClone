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
    public int getVal()
    {
        if(spriteRenderer.sprite == Black)
            return 4;
        else if(spriteRenderer.sprite == Darkest)
            return 3;
        else if(spriteRenderer.sprite == Darker)
            return 2;
        else if(spriteRenderer.sprite == Dark)
            return 1;
        else
            return 0;
    }
}
