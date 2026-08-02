using UnityEngine;

public class StartPlayingGramaphoneSound : MonoBehaviour
{
    [SerializeField] GramophoneRotate gramophoneRotate;
    [SerializeField] AudioSource audioSource;

    private bool triggerd = false;

    public void Trigger()
    {
        if (triggerd) return;

        triggerd = true;
        Invoke("PlayTrigger", 3);
    }

    private void PlayTrigger()
    {
        gramophoneRotate.StartSpin();
        audioSource.Play();
    }
}
