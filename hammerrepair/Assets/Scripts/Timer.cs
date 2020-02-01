using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public int time = 10;
    public UnityEvent TimeOut;

    bool isCountDown = false;
    private float nowTime;
    private Text timerText;
    void Start()
    {
        nowTime = time;
        timerText = GetComponent<Text>() ;
        timerText.text = ((int)time).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCountDown)
        {
            nowTime -= Time.deltaTime;
            timerText.text = ((int)nowTime).ToString();
            if (nowTime <= 0)
            {
                StopTimer();
                timerText.text = "0";
                TimeOut.Invoke();
            }
        }
    }

    public void StartTimer()
    {
        isCountDown = true;
    }

    public void StopTimer()
    {
        isCountDown = false;
    }

}
