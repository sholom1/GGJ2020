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
    public GameObject mainUIBackgroundGO;
    public GameObject loadingGO;

    private enum GameState
    {
        Menu,
        LoadingLevel,
        WaitingLevelStart,
        OnLevel,
        WinLevel,
        GameWin,
        GameLose,
    }

    private GameState nowGameState;
    private int nowLevelIndex;
    private float nowCountDown = 3;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        nowGameState = GameState.Menu;
        nowLevelIndex = 0;

        if(SceneManager.GetActiveScene().buildIndex != 0 )
        {
            nowGameState = GameState.WaitingLevelStart;
            nowLevelIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(nowGameState)
        {
            case GameState.Menu:
                if(Input.anyKeyDown)
                {
                    //GameStart();
                }
                break;

            case GameState.LoadingLevel:
                if (!loadingGO.activeSelf)
                {
                    loadingGO.SetActive(true);
                }

                if (SceneManager.GetActiveScene().isLoaded)
                {
                    loadingGO.SetActive(false);
                    timer.gameObject.SetActive(true);
                    nowGameState = GameState.WaitingLevelStart;
                }
                break;

            case GameState.WaitingLevelStart:
                break;


            case GameState.OnLevel:
                nowCountDown -= Time.deltaTime;
                if (nowCountDown <= 0)
                {
                    timer.text = "0";
                    nowGameState = GameState.GameLose;
                }
                else
                    timer.text = ((int)nowCountDown).ToString();

                break;

            case GameState.WinLevel:
                break;
            case GameState.GameWin:
                break;
            case GameState.GameLose:
                break;
            default:
                break;
        }

    }

    public void GameStart()
    {
        mainUIBackgroundGO.SetActive(false);
        loadingGO.SetActive(true);
        SceneManager.LoadScene(levelsList[nowLevelIndex]);
        nowGameState = GameState.LoadingLevel;
    }

    public void SetLevelData(int levelTime)
    {
        nowCountDown = levelTime;
        timer.text = ((int)nowCountDown).ToString();
    }

    public void LevelStart(int levelTime)
    {
        nowGameState = GameState.OnLevel;
    }

    public void LevelWin()
    {
        if (nowCountDown >= 0.0f)
        {
            GoToNextLevel();
        }
    }

    public void GameWin()
    {
    }

    public void GameLose()
    {
        nowGameState = GameState.GameLose;
    }


    private void GoToNextLevel()
    {
        if(nowLevelIndex<levelsList.Count)
        {
            SceneManager.LoadScene(levelsList[++nowLevelIndex]);
            nowGameState = GameState.LoadingLevel;
        }
        else
            nowGameState = GameState.GameWin;

    }
}
