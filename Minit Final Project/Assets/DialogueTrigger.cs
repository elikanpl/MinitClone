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
    
    public MinitDialogue dialogueController;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        dialogueController.SetPos(transform.position);
        dialogueController.SetText(text);
        dialogueController.StartTyping();
    }
}
