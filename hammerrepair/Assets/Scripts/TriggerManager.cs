using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerManager : MonoBehaviour
{
    public List<Trigger> Triggers;
    public int nextLevel;
    public UnityEvent OnWin;
    public bool RandomizeKeys = true;

    // TODO(jkachmar): Try to find a simple algorithm to generate valid 
    // key-combos that cannot register arbitrary combinations of simultaneous
    // keypresses
    //
    // Valid key combos on jkachmar's computer (late 2016 MacBook Pro):
    // - R, U, Y, G
    private void Start()
    {
        if (RandomizeKeys)
        {
            foreach (var trigger in Triggers)
            {
                var poolSize = InputDictionary.instance.KeyPool.Count;
                var requiredKey = InputDictionary.instance.KeyPool[Random.Range(0, poolSize)];

                trigger.RequiredKey = requiredKey;
                trigger.Letter.text = requiredKey.ToString();
                InputDictionary.instance.KeyPool.Remove(requiredKey);
            }
        }
    }
    void LateUpdate()
    {
        var allKeysDown = true;
        foreach (var trigger in Triggers)
        {
            var isKeyDown = Input.GetKey(trigger.RequiredKey);
            allKeysDown = allKeysDown && isKeyDown;
        }
        if (allKeysDown) {
            Debug.Log("YOU WIN!!!");
            OnWin.Invoke();
        }
    }
    public void DisableInputsForAllTriggers()
    {
        foreach(Trigger trigger in Triggers)
        {
            trigger.enabled = false;
        }
    }
}
