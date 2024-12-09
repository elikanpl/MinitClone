using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinitDialogue : MonoBehaviour
{
    public float charTiming = 0.1f;
    float timer = 0;
    int charMarker = 0;
    String currentDialogue;
    String onUIString;
    TextMeshProUGUI textMesh;
    bool typing = false;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        image = GetComponentInParent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(typing)
        {
        timer += Time.deltaTime;
            if(timer > charTiming)
            {
                if(charMarker < currentDialogue.Length)
                {
                    if(currentDialogue[charMarker] == '\n')
                        transform.parent.transform.position += new Vector3(0,14,0);
                    onUIString += currentDialogue[charMarker];
                    textMesh.text = onUIString;
                    charMarker += 1;
                }
                else
                {
                    typing = false;
                }
                timer = 0;
            }
        }

    }
    public void SetText(String s)
    {
        currentDialogue = s;
    }

    public void StartTyping(float f)
    {
        charTiming = f;
        typing = true;
        image.enabled = true;
        onUIString = "";
        charMarker = 0;

    }

    public void closeText()
    {
        typing = false;
        image.enabled = false;
        textMesh.text = "";

    }

    public void SetPos(Vector3 pos)
    {
        transform.parent.transform.position = Camera.main.WorldToScreenPoint(pos);
        Debug.Log(transform.position);
    }
}
