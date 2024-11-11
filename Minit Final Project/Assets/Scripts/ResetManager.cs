using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public static List<ResetableObject> returnList;
    // Start is called before the first frame update
    void Start()
    {
        if(returnList == null)
        {
            returnList = new List<ResetableObject>();
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
