using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Trigger : MonoBehaviour
{
    public UnityEvent OnPressed;

    public UnityEvent OnEnabled;
    public UnityEvent OnReleased;
    public KeyCode RequiredKey;

    public TextMeshProUGUI Letter;

    private void Update()
    {
        if (Input.GetKeyDown(RequiredKey))
        {
            OnPressed.Invoke();
        }
        else if (Input.GetKeyUp(RequiredKey))
        {
            OnReleased.Invoke();
        }   
    }
    private void Awake()
    {
        Debug.Log("Enabled");
        Letter.text = RequiredKey.ToString();
        OnEnabled.Invoke();   
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1000);
    }
}
