using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        GameController.Instance.GameStart();
    }
    public void UpdateSoundUI()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
