using RTLTMPro;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    public float writeInterval;
    public RTLTextMeshPro messageText;
    public AudioSource audioSource;
    public AudioClip writeClip;

    private float timer;
    private int wordIndex;
    private string message = "به آنچه میبینی اعتماد کن، مگر اینکه چیزی را ببینی که نباید آنجا باشد.";

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= writeInterval && wordIndex < message.Length)
        {
            timer = 0;
            messageText.text = message.Substring(0, wordIndex);
            wordIndex += 1;
            audioSource.PlayOneShot(writeClip);
        }
    }
}
