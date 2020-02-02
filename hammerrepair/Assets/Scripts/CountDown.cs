using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public AudioSource source;
    public AudioClip Clip;
    public CountdownNumberClipPair[] AudioNumberPairs;
    public float TimeBetweenClips;
    public Image TimerGUI;
    public Image CircleUI;
    public Image StartUI;

    public Animator anim;

    public UnityEvent OnTimerComplete;
    private void Start()
    {
        StartCoroutine(CountDownCoroutine());
    }

    [System.Obsolete]
    private IEnumerator CountDownCoroutine()
    {
        source.clip = Clip;
        source.Play();
        for(int i = 0; i < AudioNumberPairs.Length; i++)
        {
            float timer = AudioNumberPairs[i].TimeStamp;
            TimerGUI.sprite = AudioNumberPairs[i].Number;
            Debug.Log(timer);
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                yield return null;
            }
        }
        TimerGUI.gameObject.SetActive(false);
        CircleUI.gameObject.SetActive(false);
        StartUI.gameObject.SetActive(true);
        FindObjectOfType<LevelManager>().GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(TimeBetweenClips);
        OnTimerComplete.Invoke();

        //GameController.Instance.LevelStart();
    }
}
[System.Serializable]
public class CountdownNumberClipPair
{
    public float TimeStamp;
    public Sprite Number;
}
