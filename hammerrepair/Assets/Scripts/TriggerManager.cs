using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerManager : MonoBehaviour
{
    public List<Trigger> Triggers;
    public List<Trigger> AntiTriggers;
    public int nextLevel;
    public UnityEvent OnWin;
    public bool RandomizeKeys = true;

    // TODO(jkachmar): Try to find a simple algorithm to generate valid 
    // key-combos that cannot register arbitrary combinations of simultaneous
    // keypresses
    //
    // Valid key combos on jkachmar's computer (late 2016 MacBook Pro):
    // - R, U, Y, G
    //Invalid key combos on Sam's computer (Windows 10 Dell Laptop):
    // - Y, G, M, H
    // - Y, T, J, V
    // - Y, T, J, M
    // - T, M, V
    // - R, T, I, M
    private void Start()
    {
        AddKeysToTriggers();
    }

    public void AddKeysToTriggers()
    {
        if (RandomizeKeys)
        {
            var allTriggers = new List<Trigger>();
            allTriggers.AddRange(Triggers);
            allTriggers.AddRange(AntiTriggers);

            foreach (var trigger in allTriggers)
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

        foreach (var trigger in AntiTriggers)
        {
            var isKeyDown = Input.GetKey(trigger.RequiredKey);
            allKeysDown = allKeysDown && !isKeyDown;
        }

        if (allKeysDown) {
            Debug.Log("YOU WIN!!!");
            //foreach (var trigger in Triggers)
            //{
            //    Debug.Log($"trigger ${trigger.name} is ${Input.GetKey(trigger.RequiredKey)}");
            //}
            //foreach (var trigger in AntiTriggers)
            //{
            //    Debug.Log($"anti-trigger ${trigger.name} is ${Input.GetKey(trigger.RequiredKey)}");
            //}
            Win();
        }
    }
    public void Win()
    {
        OnWin.Invoke();
    }
    public void DisableInputsForAllTriggers()
    {
        foreach(Trigger trigger in Triggers)
        {
            trigger.enabled = false;
        }
    }
}
