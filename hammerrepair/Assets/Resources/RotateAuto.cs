using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAuto : MonoBehaviour
{
    public float rotateSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angles = transform.rotation.eulerAngles +  new Vector3(0.0f, 0.0f, rotateSpeed);
        GetComponent<RectTransform>().rotation.eulerAngles.Set(0.0f, 0.0f, angles.z);
    }
}
