using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [TextArea(15,20)]
    public String text;
    public float scrollSpeed = .1f;

    public MinitDialogue dialogueController;

    void Start()
    {
        dialogueController = FindAnyObjectByType<MinitDialogue>();
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        dialogueController.SetPos(transform.position);
        dialogueController.SetText(text);
        dialogueController.StartTyping(scrollSpeed);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        dialogueController.closeText();
    }
}
