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
    private GameObject timerBackground;
    public bool TimerActive;

    public float currentTime;
    public AudioSource tickSound;
    public AudioSource timerStartSound;
    private void Awake()
    {
        reference = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        timerBackground = GameObject.Find("TimerBackground");
        timerBackground.SetActive(false);
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
                if(currentTime < 11)
                {
                    if(!tickSound.isPlaying) tickSound.Play();
                }
            }
            else
            {
                Player player = GameObject.Find("Player").GetComponent<Player>();
                TextManager.reference.DisplayDeath("Time's up!");
                player.Die();
                tickSound.Stop();
            }
        }
        else
        {
            tickSound.Stop();
        }
    }

    public void TimerStart()
    {
        if(timerStartSound != null) timerStartSound.Play();
        timerBackground.SetActive(true);
        TimerActive = true;
    }

    public void ResetRun()
    {
        foreach(ResetableObject  g in returnList)
        {
            g.Reset();
        }
        if (Inventory.reference.sword)
        {
            TimerActive = true;
            currentTime = 60f;
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
