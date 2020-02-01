using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public int time = 10;
    public UnityEvent Win;
    public UnityEvent Lose;

    void Start()
    {
        GameController.Instance.SetLevelData(this);
    }

    public void WinLevel()
    {
        Win.Invoke();
    }

    public void LoseLevel()
    {
        Lose.Invoke();
    }
}
