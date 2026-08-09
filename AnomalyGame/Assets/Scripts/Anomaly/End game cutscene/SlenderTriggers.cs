using UnityEngine;

public class SlenderTriggers : MonoBehaviour
{
    public EndgameCutsceneDirector cutsceneDirector;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip fallClip;
    public AudioClip screamClip;

    public void PlayFallClip() 
    {
        audioSource.PlayOneShot(fallClip);
        // TODO: screan shake
    }

    public void PlayScreamClip()
    {
        audioSource.clip = screamClip;
        audioSource.Play();
    }

    public void StopScreamClip()
    {
        audioSource.Stop();
    }

    public void FadeIn()
    {
        cutsceneDirector.FadeIn();
    }
}
