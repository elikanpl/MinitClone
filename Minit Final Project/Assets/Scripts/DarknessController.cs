using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DarknessController : MonoBehaviour
{

    DarknessObject[,] darkArray;
    public GameObject darkObj;

    GameObject playerRef;

    public bool enabled = false;

    (int,int) savedTile = (0,0);
    // Start is called before the first frame update
    void Start()
    {
        darkArray = new DarknessObject[20,15];
        for(int i = 0; i < 20; i ++)
        {
            for(int j = 0; j < 15; j++)
            {
                GameObject g = Instantiate(darkObj,transform.position + new Vector3(i + .5f,-j -.5f,0),Quaternion.identity);
                darkArray[i,j] = g.GetComponent<DarknessObject>();
            }
        }

        playerRef = FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {
        if(enabled)
        {
            (int,int) currentTile = ((int)Mathf.Floor(playerRef.transform.position.x-transform.position.x), (int)Mathf.Floor(transform.position.y-playerRef.transform.position.y));
            if(currentTile != savedTile)
            {
                
                savedTile = currentTile;
                Debug.Log(savedTile);
                drawNew(savedTile);
            }
        }
    }

    void drawNew((int x,int y) tile)
    {
        for(int i = tile.x -6; i <= tile.x + 6; i++)
        {
            for(int j = tile.y -6; j <= tile.y + 6; j++)
            {
                if(Mathf.Abs(i -tile.x) > 5 || Mathf.Abs(j - tile.y) > 5)
                    setTileAt((i,j),4);
                else if(Mathf.Abs(i -tile.x) > 4 || Mathf.Abs(j - tile.y) > 4)
                    setTileAt((i,j),3);
                else if(Mathf.Abs(i -tile.x) > 3 || Mathf.Abs(j - tile.y) > 3)
                    setTileAt((i,j),2);
                else if(Mathf.Abs(i -tile.x) > 2 || Mathf.Abs(j - tile.y) > 2)
                    setTileAt((i,j),1);
                else
                    setTileAt((i,j),0);
            }
        }
    }

    bool setTileAt((int x, int y) tile, int c)
    {
        if(tile.x > 19 || tile.x < 0)
            return false;
        if(tile.y > 14 || tile.y < 0)
            return false;
        if(c == 4)
            darkArray[tile.x,tile.y].setBlack();
        if(c == 3)
            darkArray[tile.x,tile.y].setDarkest();
        if(c == 2)
            darkArray[tile.x,tile.y].setDarker();
        if(c == 1)
            darkArray[tile.x,tile.y].setDark();
        if(c == 0)
            darkArray[tile.x,tile.y].noDark();
        return true;
    }

}
