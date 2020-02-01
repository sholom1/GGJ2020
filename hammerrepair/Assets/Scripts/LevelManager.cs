using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }
    public GameObject LodingScreen;
    public void LoadScene(int index)
    {
        LodingScreen.SetActive(true);
        SceneManager.LoadScene(index);
    }
}
