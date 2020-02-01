using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent OnPressed;

    public UnityEvent OnEnabled;
    public UnityEvent OnReleased;
    public KeyCode RequiredKey;

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
    void OnEnable()
    {
        OnEnabled.Invoke();
    }
}
