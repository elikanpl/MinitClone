using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    private float x;
    private float newX;
    //private float originalY;
    public float speed;
    public float xSize;
    public float minX;
    public float maxX;
    private Vector3 newPosition;
    private float accurateTime;
    private Vector3 changePosition;

    // Start is called before the first frame update
    void Start()
    {
        minX = this.transform.position.x - xSize;
        maxX = this.transform.position.x + xSize;
        x = Random.Range(minX, maxX);
        newPosition = new Vector3(x, this.transform.position.y, this.transform.position.z);
        this.transform.position = newPosition;
        //originalY = this.transform.position.y;
        accurateTime = Time.deltaTime;
        changePosition = new Vector3(speed, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        x = this.transform.position.x;
        accurateTime = Time.deltaTime;
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        newX = x + speed * accurateTime;
        if (newX <= minX)
        {
            speed *= -1;
            changePosition = new Vector3(speed, 0f, 0f);
        }
        else if (newX >= maxX)
        {
            speed *= -1;
            changePosition = new Vector3(speed, 0f, 0f);
        }
        else
        {
            newPosition += changePosition * accurateTime;
            this.transform.position = newPosition;
        }
    }

}
