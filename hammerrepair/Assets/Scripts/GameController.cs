using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    public List<int> levelsList;

    public Canvas mainUI;
    public Text timer;
    public GameObject loadingImage;

    private enum GameState
    {
        Start,
        LoadingLevel,
        OnLevel,
        WinLevel,
        Win,
        Lose,
    }

    private GameState nowGameState;
    private int nowLevelIndex;
    private float nowCountDown = 3;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(mainUI.gameObject);

        nowGameState = GameState.Start;
        nowLevelIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(nowGameState)
        {
            case GameState.Start:
                if(Input.anyKeyDown)
                {
                    SceneManager.LoadScene(levelsList[nowLevelIndex]);
                    nowGameState = GameState.LoadingLevel;
                }
                break;

            case GameState.LoadingLevel:
                if (SceneManager.GetActiveScene().isLoaded)
                {
                    nowGameState = GameState.OnLevel;
                }
                break;

            case GameState.OnLevel:


                nowCountDown -= Time.deltaTime;
                if (nowCountDown <= 0)
                {
                    timer.text = "0";
                    nowGameState = GameState.Lose;
                }
                else
                    timer.text = ((int)nowCountDown).ToString();

                break;

            case GameState.WinLevel:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            default:
                break;
        }

    }

    public void SetLevelData(int levelTime)
    {
        nowCountDown = levelTime;
        timer.text = ((int)nowCountDown).ToString();
    }

    public void StartLevel(int levelTime)
    {
        nowGameState = GameState.OnLevel;
    }

    public void WinLevel()
    {
        if (nowCountDown >= 0.0f)
        {
            GoToNextLevel();
        }
    }

    private void GoToNextLevel()
    {
        if(nowLevelIndex<levelsList.Count)
        {
            SceneManager.LoadScene(levelsList[++nowLevelIndex]);
            nowGameState = GameState.LoadingLevel;
        }
        else
            nowGameState = GameState.OnLevel;

    }
}
