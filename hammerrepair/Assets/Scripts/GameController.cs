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
    public GameObject menu;
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

    private LevelManager nowLevelManager;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        nowGameState = GameState.Menu;
        nowLevelIndex = 0;

        if(SceneManager.GetActiveScene().buildIndex != 0 )
        {
            nowGameState = GameState.WaitingLevelStart;
            nowLevelIndex = SceneManager.GetActiveScene().buildIndex;
            GameObject startItem =  GameObject.Instantiate( Resources.Load<GameObject>("StartItem"));
            startItem.transform.SetParent(this.transform);
            mainUI = startItem.transform.Find("MainUI").GetComponent<Canvas>();
            timer = startItem.transform.Find("MainUI/Timer").GetComponent<Text>();
            menu = startItem.transform.Find("MainUI/Menu").gameObject;
            loadingGO = startItem.transform.Find("MainUI/Loading").gameObject;
            
            CloseAllUI();
            timer.gameObject.SetActive(true);
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
                    CloseAllUI();
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
                GameLose();
                break;
            default:
                break;
        }

    }

    public void GameStart()
    {
        menu.SetActive(false);
        loadingGO.SetActive(true);
        SceneManager.LoadScene(levelsList[nowLevelIndex]);
        nowGameState = GameState.LoadingLevel;
    }

    public void SetLevelData(LevelManager levelManager)
    {
        nowLevelManager = levelManager;

        nowCountDown = nowLevelManager.time;
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
            nowLevelManager.WinLevel();
            GoToNextLevel();
        }
    }

    public void GameWin()
    {
    }

    public void GameLose()
    {
        nowLevelManager.LoseLevel();
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

    private void CloseAllUI()
    {
        timer.gameObject.SetActive(false);
        menu.SetActive(false);
        loadingGO.SetActive(false);
    }
}
