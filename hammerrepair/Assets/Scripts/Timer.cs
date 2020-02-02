using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    [HideInInspector]
    public int time = 10;
    public UnityEvent TimeOut;

    bool isCountDown = false;
    [HideInInspector]
    public float nowTime;
    private TextMeshProUGUI timerText;

    void Start()
    {
        nowTime = time +0.5f;
        timerText = GetComponent<TextMeshProUGUI>() ;
        timerText.text = ((int)time).ToString();
        timerText.enabled = false;
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
        timerText.enabled = true;
    }

    public void StopTimer()
    {
        isCountDown = false;
    }

    public int GetSpendTime()
    {
        return time - (int)nowTime;
    }

}
