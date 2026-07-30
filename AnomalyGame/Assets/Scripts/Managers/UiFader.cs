using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UiFader : MonoBehaviour
{
    [SerializeField] private Image image;
    [HideInInspector]

    private Coroutine fadeCoroutine;

    public void FadeIn(float duration = 3)
    {
        StartFade(0f, 1f, duration);
    }

    public void FadeOut(float duration = 3)
    {
        StartFade(1f, 0f, duration);
    }

    private void StartFade(float startAlpha, float endAlpha, float duration)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeRoutine(startAlpha, endAlpha, duration));
    }

    private IEnumerator FadeRoutine(float startAlpha, float endAlpha, float duration)
    {
        float time = 0f;
        Color color = image.color;
        color.a = startAlpha;
        image.color = color;

        while (time < duration)
        {
            time += Time.deltaTime;

            color.a = Mathf.Lerp(startAlpha, endAlpha, time / duration);
            image.color = color;

            yield return null;
        }

        color.a = endAlpha;
        image.color = color;
    }
}
