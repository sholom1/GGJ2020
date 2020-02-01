using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ArrayAnimatorScript : MonoBehaviour
{

    public float animationWait;
    public Sprite[] AnimationArray;
    private Image image;

    public bool playOnStart = false;
    public bool repeatForever = false;
    public bool removeOnFinish = false;
    public float startDelayMs = 0f;

    private bool isAnimating;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start() {
        if (playOnStart) {
            Play();
        }
    }

    public void Play() {
        if (isAnimating) {
            return;
        }
        StopAllCoroutines();
        StartCoroutine(Animate());
    }
    private void OnDisable()
    {
        Stop();
    }
    public void Stop() {
        isAnimating = false;
        StopAllCoroutines();
    }

    public IEnumerator Animate()
    {
        if (startDelayMs > 0) {
            yield return new WaitForSeconds(startDelayMs/1000f);
        }
        isAnimating = true;
        do {
            foreach (Sprite sprite in AnimationArray)
            {
                image.sprite = sprite;
                yield return new WaitForSeconds(animationWait);
            }
        } while(repeatForever);
        if (removeOnFinish) {
            image.sprite = null;
        }
        isAnimating = false;
    }
}
