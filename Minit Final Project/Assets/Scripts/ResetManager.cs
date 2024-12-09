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
    public AudioSource tickSound;

    private void Awake()
    {
        reference = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        if(returnList == null)
        {
            returnList = new List<ResetableObject>();
        }
        currentTime = 60f;
        textMesh.text = "";
        tickSound = GetComponent<AudioSource>();
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
                if(currentTime < 11)
                {
                    if(!tickSound.isPlaying) tickSound.Play();
                }
            }
            else
            {
                Player player = GameObject.Find("Player").GetComponent<Player>();
                player.Die();
                tickSound.Stop();
            }
        //if(Input.GetKeyDown(KeyCode.R))
        //{
        //    TimerActive = true;
        //    currentTime = 60f;

        //}
        }
    }

    public void TimerStart()
    {
        // Add timer start sound here
        TimerActive = true;
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
