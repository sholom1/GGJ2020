using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Slider AudioSlider;
    public void PlayGame()
    {
        GameController.Instance.GameStart();
    }
    public void AdjustMasterVolume()
    {
        AudioListener.volume = AudioSlider.value / AudioSlider.maxValue;
    }
    public void MuteMasterAudio(bool toggle)
    {
        AudioListener.volume = toggle ? 0 : AudioSlider.value / AudioSlider.maxValue;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
