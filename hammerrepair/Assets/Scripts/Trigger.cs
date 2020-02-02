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

    bool hasInvokedOnPress = false;

    public TextMeshProUGUI Letter;
    public GameObject symbol;
    private GameController GameManager;
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
        GameManager = GameObject.Find("GameController").GetComponent<GameController>();
        Debug.Log("Enabled");
        if (Letter != null)
        {
            Letter.fontStyle = FontStyles.Bold;
            Letter.text = RequiredKey.ToString().ToLower();
        }
        OnEnabled.Invoke();

        if (GameManager.isHardMode)
        {
            Debug.Log("TRUE" + "HardModeSymbols/" + RequiredKey.ToString());
            Letter.enabled = false;
            symbol.SetActive(true);
            symbol.GetComponent<Image>().sprite = Resources.Load<Sprite>(("HardModeSymbols/" + RequiredKey.ToString()));
        }
        else
        {
            Debug.Log("FALSE");
            symbol.SetActive(false);
        }

    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1000);
    }
    public void enableTextOrSymbol()
    {
        Debug.Log("ENABLING MAYBE");
        if (GameManager.isHardMode)
        {
            Debug.Log("TRUE" + "HardModeSymbols/" + RequiredKey.ToString());
            Letter.enabled = false;
            symbol.SetActive(true);
            symbol.GetComponent<Image>().sprite = Resources.Load<Sprite>(("HardModeSymbols/" + RequiredKey.ToString()));
        }
        else
        {
            Debug.Log("FALSE");
            symbol.SetActive(false);
        }
    }
}
