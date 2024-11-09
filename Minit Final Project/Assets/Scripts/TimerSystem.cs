using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    bool countdown;
    float currentTime;
    ResetManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<ResetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown)
        {
            if(currentTime > 0)
            {
                Debug.Log(currentTime);
                currentTime -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time!");
                manager.ResetRun();
                countdown = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            countdown = true;
            currentTime = 60f;

        }
    }
}
