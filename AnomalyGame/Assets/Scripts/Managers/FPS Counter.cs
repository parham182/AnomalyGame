using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsText;
    [SerializeField] private float updateRate = 0.25f;

    private float timer;

    void Update()
    {
        timer += Time.unscaledDeltaTime;

        if (timer >= updateRate)
        {
            int fps = Mathf.RoundToInt(1f / Time.unscaledDeltaTime);
            fpsText.text = $"FPS: {fps}";
            timer = 0f;
        }
    }
}
