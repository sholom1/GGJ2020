using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    public List<int> levelsList;

    //public Canvas mainUI;
    //public Text timer;
    //public GameObject loadingGO;

    private enum GameState
    {
        Menu,
        OnLevel,
        WinLevel,
        GameWin,
        GameLose,
    }

    private GameState nowGameState;
    private int nowLevelIndex;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (GameController.Instance != this)
            Destroy(this.transform.gameObject);

        nowGameState = GameState.Menu;
        nowLevelIndex = 0;

        if(SceneManager.GetActiveScene().buildIndex != 0 )
        {
            nowGameState = GameState.OnLevel;
            levelsList = new List<int>();
            levelsList.Add(SceneManager.GetActiveScene().buildIndex);
            nowLevelIndex = 1;

            //GameObject startItem =  GameObject.Instantiate( Resources.Load<GameObject>("StartItem"));
            //startItem.transform.SetParent(this.transform);
            //mainUI = startItem.transform.Find("MainUI").GetComponent<Canvas>();
            //timer = startItem.transform.Find("MainUI/Timer").GetComponent<Text>();
            //loadingGO = startItem.transform.Find("MainUI/Loading").gameObject;
            
            //CloseAllUI();
            //timer.gameObject.SetActive(true);
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

            //case GameState.LoadingLevel:
            //    if (!loadingGO.activeSelf)
            //    {
            //        loadingGO.SetActive(true);
            //    }

            //    if (SceneManager.GetActiveScene().isLoaded)
            //    {
            //        CloseAllUI();
            //        //timer.gameObject.SetActive(true);
            //        nowGameState = GameState.WaitingLevelStart;
            //    }
            //    break;
            case GameState.OnLevel:
                break;

            case GameState.WinLevel:
                break;
            case GameState.GameWin:
                SceneManager.LoadScene(0);
                nowGameState = GameState.Menu;
                nowLevelIndex = 0;

                break;
            case GameState.GameLose:
                GameLose();
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene(0);
                    nowGameState = GameState.Menu;
                    nowLevelIndex = 0;
                }
                break;
            default:
                break;
        }

    }

    public void GameStart()
    {
        SceneManager.LoadScene(levelsList[nowLevelIndex]);
        nowGameState = GameState.OnLevel;
    }

    public void LevelWin()
    {
        // go to next level
        if (++nowLevelIndex < levelsList.Count)
        {
            SceneManager.LoadScene(levelsList[nowLevelIndex]);
            nowGameState = GameState.OnLevel;
        }
        else
            nowGameState = GameState.GameWin;
    }

    public void GameWin()
    {
    }

    public void GameLose()
    {
        nowGameState = GameState.GameLose;
    }
}
