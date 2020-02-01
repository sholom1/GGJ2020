using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent OnPressed;
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
    public void TestPressed()
    {
        Debug.Log("The key has been pressed");
    }
    public void TestRelease()
    {
        Debug.Log("The key has been released");
    }
}
public class Leak
{
    public KeyCode RequiredKey;
    public float TimeToExplode;
    public float TimeToRepair;
    public float TimeBetweenLeaks;
}
