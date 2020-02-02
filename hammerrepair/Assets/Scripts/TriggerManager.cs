using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public List<Trigger> Triggers;
    public int nextLevel;
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
        GameController.Instance.LevelWin();
    }
}
