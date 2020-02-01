using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public List<Trigger> Triggers;
    public int nextLevel;
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
