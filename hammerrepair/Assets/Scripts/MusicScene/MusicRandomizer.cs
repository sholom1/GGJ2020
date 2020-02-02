using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRandomizer : MonoBehaviour
{
    public List<AudioSource> Sources;
    public List<Trigger> Triggers;
    public GameObject EventSystem;

    // Start is called before the first frame update
    void Start()
    {
        int bad1 = Random.Range(0,6);
        //int bad2;
        //do
        //{
        //    bad2 = Random.Range(0,6);
        //} while (bad1 == bad2);

        var triggerManager = EventSystem.GetComponent<TriggerManager>();
        var triggerList = triggerManager.Triggers;
        var antiTriggerList = triggerManager.AntiTriggers;
        triggerList.Clear();
        antiTriggerList.Clear();

        for (int i = 0; i< 6; i++) {
            if (i==bad1) {
                antiTriggerList.Add(Triggers[i]);
                Debug.Log($"Added anti-trigger for bad tune ${Triggers[i].name}");

                Sources[2*i].enabled = false;
                //Debug.Log($"Disabled good tune ${Sources[2 * i].name}");
            } else
            {
                triggerList.Add(Triggers[i]);
                //Debug.Log($"Added trigger ${Triggers[i].name}");

                Sources[2*i+1].enabled = false;
                //Debug.Log($"Disabled bad tune ${Sources[2 * i+1].name}");
           }
        }

        triggerManager.AddKeysToTriggers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
