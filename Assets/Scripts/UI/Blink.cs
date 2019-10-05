using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    private Text text;
    public float blinkSpeed = 0.8f;

    public enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    void OnEnable()
    {
        StartCoroutine(Fade(FadeDirection.Out));
    }

    private IEnumerator Fade(FadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;
        if (fadeDirection == FadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            yield return Fade(FadeDirection.In);
        }
        else
        {
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            yield return Fade(FadeDirection.Out);
        }
    }

    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / blinkSpeed) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }
}
