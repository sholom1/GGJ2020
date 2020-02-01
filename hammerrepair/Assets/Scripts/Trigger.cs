using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Trigger : MonoBehaviour
{
    public UnityEvent OnPressed;

    public UnityEvent OnEnabled;
    public UnityEvent OnReleased;
    public KeyCode RequiredKey;

    public TextMeshProUGUI Letter;

    private void Update()
    {
        if (Input.GetKeyDown(RequiredKey))
        {
            OnPressed.Invoke();
        }
        else if (Input.GetKeyUp(RequiredKey))
        {
            OnReleased.Invoke();
        }   
    }
    private void Start()
    {
        RequiredKey = InputDictionary.instance.KeyPool[Random.Range(0, InputDictionary.instance.KeyPool.Count)];
        InputDictionary.instance.KeyPool.Remove(RequiredKey);
        Letter.text = RequiredKey.ToString();
    }
    private void Awake()
    {
        Debug.Log("Enabled");
        OnEnabled.Invoke();   
    }
}
