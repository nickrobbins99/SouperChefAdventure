using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int initialSeconds;
    public int initialMinutes;
    private int mins;
    private int seconds;
    public bool active;
    public AppetitePicker appetitePicker;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        UpdateText();
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }
    public void StartTimer()
    {
        mins = initialMinutes;
        seconds = initialSeconds;
        active = true;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateText()
    {
        if (seconds < 10)
        {
            if (mins < 10)
            {
                GetComponent<Text>().text = "0" + mins + ":0" + seconds;
            }
            else
            {
                GetComponent<Text>().text = mins + ":0" + seconds;
            }
        }
        else
        {
            if (mins < 10)
            {
                GetComponent<Text>().text = "0" + mins + ":" + seconds;
            }
            else
            {
                GetComponent<Text>().text = mins + ":" + seconds;
            }
        }
    }
    void UpdateTimer()
    {
        if (active)
        {
            UpdateText();
            if (seconds > 0)
            {
                seconds -= 1;
            }
            else if (seconds == 0)
            {
                if (mins == 0)
                {
                    active = false;
                    //grade soup
                    appetitePicker.GradeSoup();
                }
                mins -= 1;
                seconds = 59;
            }
        }
    }
}
