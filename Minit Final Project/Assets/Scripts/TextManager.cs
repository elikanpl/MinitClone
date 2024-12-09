using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public static TextManager reference;
    private TextMeshProUGUI deathText;
    private TextMeshProUGUI controlsText;
    private TextMeshProUGUI itemText;
    // Start is called before the first frame update

    private void Awake()
    {
        reference = this;
    }
    void Start()
    {
        deathText = GameObject.Find("DeathText").GetComponent<TextMeshProUGUI>();
        deathText.enabled = false;
        controlsText = GameObject.Find("ControlsText").GetComponent<TextMeshProUGUI>();
        controlsText.enabled = false;
        itemText = GameObject.Find("ItemText").GetComponent<TextMeshProUGUI>();
        itemText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayDeath(string message)
    {
        deathText.text = message;
        deathText.enabled = true;
    }

    public void HideDeath()
    {
        deathText.enabled = false;
    }

    public void DisplayControls(string message)
    {
        controlsText.text = message;
        controlsText.enabled = true;
    }

    public void HideControls()
    {
        controlsText.enabled = false;
    }

    public void DisplayItemText(string message)
    {
        itemText.text = message;
        itemText.enabled = true;
    }

    public void HideItemText()
    {
        itemText.enabled = false;
    }
}
