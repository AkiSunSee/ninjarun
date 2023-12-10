using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{
    public float TimeLeft = 60f;
    public float Delay = 3f;
    public bool TimerOn = false;
    private float minutes;
    private float seconds;
    public TextMeshProUGUI TimerTxt;
    public GameObject loseText;
    void Start()
    {
        TimerOn = true;
        TimeLeft+= Delay;
        loseText.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                //Debug.Log("Time is UP");
                TimeLeft = 0;
                TimerOn = false;
                loseText.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    void updateTimer(float currentTime)
    {
    currentTime +=1;
    minutes = Mathf.FloorToInt(currentTime / 60);
    seconds = Mathf.FloorToInt(currentTime % 60);   
        TimerTxt.text =minutes+":"+seconds;
    }
}
    



