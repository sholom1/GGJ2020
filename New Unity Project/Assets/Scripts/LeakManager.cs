using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeakManager : MonoBehaviour
{
    public List<Trigger> Pipes;
    public UnityEvent OnRepaired;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //foreach (Trigger pipe in Pipes)
        //{
        //    if (pipe.RepairJobs[0].TimeToRepair > 0f)
        //    {
        //        if (Input.GetKey(pipe.RepairJobs[0].RequiredKey))
        //        {
        //            pipe.RepairJobs[0].TimeToRepair -= Time.deltaTime;
        //        }
        //        else
        //        {
        //            pipe.RepairJobs[0].TimeToExplode -= Time.deltaTime;
        //        }
        //    }
        //}
    }
}
