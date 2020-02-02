using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Trigger : MonoBehaviour
{
    public UnityEvent OnPressed;

    public UnityEvent OnEnabled;
    public UnityEvent OnReleased;
    public KeyCode RequiredKey;

    public TextMeshProUGUI Letter;
    public GameObject symbol;
    private GameController GameManager;
    private void Update()
    {
        if (Input.GetKeyDown(RequiredKey))
        {
            Debug.Log($"Pressed trigger with letter {RequiredKey.ToString()}");
            OnPressed.Invoke();
        }
        else if (Input.GetKeyUp(RequiredKey))
        {
            Debug.Log($"Released trigger with letter {RequiredKey.ToString()}");
            OnReleased.Invoke();
        }   


    }
    private void Awake()
    {
        GameManager = GameObject.Find("GameController").GetComponent<GameController>();
        Debug.Log("Enabled");
        if (Letter != null)
        {
            Letter.text = RequiredKey.ToString();
        }
        OnEnabled.Invoke();   

        if(GameManager.isHardMode)
        {
            Letter.enabled = false;
            symbol.GetComponent<Image>().sprite = Resources.Load<Sprite>(("HardModeSymbols/" + RequiredKey.ToString()));
        }
        else
        {
            symbol.SetActive(false);
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1000);
    }
}
