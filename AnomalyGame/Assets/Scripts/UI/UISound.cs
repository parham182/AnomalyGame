using UnityEngine;

public class UISound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    // singleton
    public static UISound instance;
    private void Awake() { instance = this; }

    public void PlaySound(AudioClip clip, float volume = 1)
    {
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.volume = volume;
        audioSource.PlayOneShot(clip);
    }
}
