using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerManager : MonoBehaviour
{
    public List<Trigger> Triggers;
    public int nextLevel;
    public UnityEvent OnWin;

    private void Start()
    {
        //foreach (Trigger trigger in Triggers)
        //{
        //    trigger.RequiredKey = InputDictionary.instance.KeyPool[Random.Range(0, InputDictionary.instance.KeyPool.Count)];
        //    InputDictionary.instance.KeyPool.Remove(trigger.RequiredKey);
        //    trigger.Letter.text = trigger.RequiredKey.ToString();
        //}
    }
    void Update()
    {
        foreach (Trigger trigger in Triggers)
        {
            if (!Input.GetKey(trigger.RequiredKey))
            {
                return;
            }
        }
        OnWin.Invoke();
    }
}
