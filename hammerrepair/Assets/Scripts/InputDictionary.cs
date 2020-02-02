using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InputDictionary : MonoBehaviour
{
    public static InputDictionary instance;
    private void Start()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }
    public List<KeyCode> KeyPool;
}
