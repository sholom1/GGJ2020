using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Trigger : MonoBehaviour
{
    public UnityEvent OnPressed;

    public UnityEvent OnEnabled;
    public UnityEvent OnReleased;
    public KeyCode RequiredKey;

    bool hasInvokedOnPress = false;

    public TextMeshProUGUI Letter;

    private void Update()
    {
        if (Input.GetKey(RequiredKey))
        {
            Debug.Log($"Pressed trigger with letter {RequiredKey.ToString()}");
            if (!hasInvokedOnPress) {
                OnPressed.Invoke();
                hasInvokedOnPress = true;
            }
        }
        if (Input.GetKeyUp(RequiredKey))
        {
            Debug.Log($"Released trigger with letter {RequiredKey.ToString()}");
            OnReleased.Invoke();
            hasInvokedOnPress = false;
        }
    }
    private void Awake()
    {
        Debug.Log("Enabled");
        if (Letter != null)
        {
            Letter.text = RequiredKey.ToString();
        }
        OnEnabled.Invoke();   
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1000);
    }
}
