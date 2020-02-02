using UnityEngine;

public class GradientController : MonoBehaviour
{
    public Color one;
    public Color two;
    Camera MyCamera;
    void Start()
    {
        MyCamera = Camera.main;
    }
    
    void Update() {
        MyCamera.backgroundColor = Color.Lerp(one, two, Mathf.PingPong(Time.time/1000, 1));
    }
}