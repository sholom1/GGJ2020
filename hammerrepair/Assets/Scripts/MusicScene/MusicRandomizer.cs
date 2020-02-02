using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRandomizer : MonoBehaviour
{
    public List<AudioSource> Sources;

    // Start is called before the first frame update
    void Start()
    {
        int bad1 = Random.Range(0,7);
        int bad2;
        do
        {
            bad2 = Random.Range(0,7);
        } while (bad1 == bad2);

        for (int i = 0; i< 7; i++) {
            if ((i==bad1) || (i==bad2)) {
                Sources[2*i].enabled = false;
                Debug.Log($"Disabled good tune ${Sources[2 * i].name}");
            } else
            {
                Sources[2*i+1].enabled = false;
                Debug.Log($"Disabled bad tune ${Sources[2 * i+1].name}");
           }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
