using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UiFader : MonoBehaviour
{
    [SerializeField] private Image image;
    [HideInInspector]
    public float duration = 3f;

    private Coroutine fadeCoroutine;

    public void FadeIn()
    {
        StartFade(0f, 1f);
    }

    public void FadeOut()
    {
        StartFade(1f, 0f);
    }

    private void StartFade(float startAlpha, float endAlpha)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeRoutine(startAlpha, endAlpha));
    }

    private IEnumerator FadeRoutine(float startAlpha, float endAlpha)
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
