using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ArrayAnimatorScript : MonoBehaviour
{

    public float animationWait;
    public Sprite[] AnimationArray;
    private SpriteRenderer spriteComponent;

    public bool playOnStart = false;
    public bool repeatForever = false;
    public bool removeOnFinish = false;
    public float startDelayMs = 0f;

    private bool isAnimating;

    private void Awake()
    {
        spriteComponent = GetComponent<SpriteRenderer>();
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
                spriteComponent.sprite = sprite;
                yield return new WaitForSeconds(animationWait);
            }
        } while(repeatForever);
        if (removeOnFinish) {
            spriteComponent.sprite = null;
        }
        isAnimating = false;
    }
}
