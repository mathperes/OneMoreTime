using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TImerController : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    public float countTime = 0;
    public static float countdown = 4;


    public static bool cleanTimer = false;
    public static bool isVomiting = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isVomiting)
        {
            //countdownText.gameObject.SetActive(true);
            //TimerCountDown();
        }
        if (cleanTimer)
        {
            countdownText.gameObject.SetActive(false);
            cleanTimer = false;
        }
    }

    void TimerCountDown()
    {
        if (countdown <= countTime)
        {
            countdownText.text = countTime.ToString("F0");
        }
        else
        {
            countdown -= Time.deltaTime;
            countdownText.text = "Corra! " + countdown.ToString("F0");
        }
    }
}
