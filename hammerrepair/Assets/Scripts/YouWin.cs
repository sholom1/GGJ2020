using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouWin : MonoBehaviour
{

    public Text totalTimeText;
    public GameObject pressImage;


    private bool canRetrun = false;
    // Start is called before the first frame update
    void Start()
    {
        totalTimeText.text = GameController.Instance.TotalTime.ToString();
        StartCoroutine(ShowReturn());
    }

    // Update is called once per frame
    void Update()
    {
        if(canRetrun)
        {
            if(Input.anyKeyDown)
            {
                GameController.Instance.ReturnToMenuScene();
            }
        }
    }

    private IEnumerator ShowReturn()
    {
        yield return new WaitForSeconds(3);
        pressImage.SetActive(true);
        canRetrun = true;
    }
}
