using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject LodingScreen;
    public void LoadScene(int index)
    {
        LodingScreen.SetActive(true);
        SceneManager.LoadScene(index);
    }
}
