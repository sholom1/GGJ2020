using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CountDown : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] AudioClips;
    public float TimeBetweenClips;
    public TextMeshProUGUI TimerText;

    public UnityEvent OnTimerComplete;
    private void Start()
    {
        StartCoroutine(CountDownCoroutine());
    }
    private IEnumerator CountDownCoroutine()
    {
        for(int i = AudioClips.Length-1; i >= 0; i--)
        {
            float timer = TimeBetweenClips + AudioClips[i].length;
            source.clip = AudioClips[i];
            source.Play();
            TimerText.text = $"{1 + i}";
            yield return new WaitForSeconds(timer);
        }
        TimerText.text = "GO!";
        yield return new WaitForSeconds(TimeBetweenClips);
        OnTimerComplete.Invoke();

        GameController.Instance.LevelStart();
    }
}
