using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ResetManager : MonoBehaviour
{
    public static List<ResetableObject> returnList;
    TextMeshProUGUI textMesh;
    public bool TimerActive;

    public float currentTime = 60f;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        if(returnList == null)
        {
            returnList = new List<ResetableObject>();
        }
        textMesh.text = "Press R to start Timer";
    }
    void Update()
    {
        if(TimerActive)
        {
            {
            if(currentTime > 0)
            {
                String s = ((int)currentTime).ToString();
                if(s != textMesh.text)
                    textMesh.text = ((int)currentTime).ToString();
                currentTime -= Time.deltaTime;
            }
            else
            {
                ResetRun();
                TimerActive = true;
                currentTime = 60f;
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            TimerActive = true;
            currentTime = 60f;

        }
        }
    }

    public void ResetRun()
    {
        foreach(ResetableObject  g in returnList)
        {
            g.Reset();
        }
    }

    public static void addTo(ResetableObject g)
    {
        if(returnList == null)
        {
            returnList = new List<ResetableObject>();
        }
        returnList.Add(g);
    }

}
