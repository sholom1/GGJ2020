using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public UnityEvent Win;
    public UnityEvent Lose;

    void Start()
    {
        //GameController.Instance.SetLevelData(this);
    }

    private bool isAddTime = false;
    public void WinLevel()
    {
        Win.Invoke();

        if(!isAddTime)
        {
            Timer timer = GetComponentInChildren<Timer>();
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
