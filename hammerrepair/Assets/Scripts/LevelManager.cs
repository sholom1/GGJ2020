using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int levelTime = 10;
    [Header("Play different wining sign")]
    public int amazingTime = 8;
    public int goodJobTime = 6;
    public int okTime = 4;
    public int niceTryTime = 2;

    public UnityEvent Win;
    public UnityEvent Lose;

    public UnityEvent WinAmazing;
    public UnityEvent WinGoodJob;
    public UnityEvent WinOk;
    public UnityEvent WinNiceTry;
    public UnityEvent WinMmm;

    public Timer timer;

    void Start()
    {
        timer.time = levelTime;
    }

    private bool isAddTime = false;
    public void WinLevel()
    {
        Win.Invoke();

        int nowTime = (int)timer.nowTime;
        if (nowTime >= amazingTime)
        {
            WinAmazing.Invoke();
        }
        else if (nowTime >= goodJobTime)
            WinGoodJob.Invoke();
        else if (nowTime >= okTime)
            WinOk.Invoke();
        else if (nowTime >= niceTryTime)
            WinNiceTry.Invoke();
        else
            WinMmm.Invoke();

        if (!isAddTime)
        {
            Timer timer = GetComponentInChildren<Timer>();
            GameController gameController =  GameController.Instance;
            GameController.Instance.AddTotalTime(timer.GetSpendTime());
            isAddTime = true;
        }
    }

    public void LoseLevel()
    {
        Lose.Invoke();
        //GameController.Instance.GameLose();
    }

   

    public void GoToNextLevelAfterDelay(float waitTime)
    {
        StartCoroutine(waitForNextLevel(waitTime));
    }

    private IEnumerator waitForNextLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameController.Instance.LevelWin();
    }

    public void RestartLevelAfterDelay(float waitTime)
    {
        StartCoroutine(waitForRestart(waitTime));
    }

    private IEnumerator waitForRestart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
