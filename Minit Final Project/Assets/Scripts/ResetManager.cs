using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ResetManager : MonoBehaviour
{
    public static ResetManager reference;
    public static List<ResetableObject> returnList;
    TextMeshProUGUI textMesh;
    public bool TimerActive;

    public float currentTime;

    private void Awake()
    {
        reference = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        if(returnList == null)
        {
            returnList = new List<ResetableObject>();
        }
        currentTime = 60f;
        textMesh.text = "";
    }
    void Update()
    {
        if(TimerActive)
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
                Player player = GameObject.Find("Player").GetComponent<Player>();
                player.Die();
            }
        //if(Input.GetKeyDown(KeyCode.R))
        //{
        //    TimerActive = true;
        //    currentTime = 60f;

        //}
        }
    }

    public void ResetRun()
    {
        foreach(ResetableObject  g in returnList)
        {
            g.Reset();
        }
        TimerActive = true;
        currentTime = 60f;
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
