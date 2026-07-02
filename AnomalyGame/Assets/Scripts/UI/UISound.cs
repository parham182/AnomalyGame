using UnityEngine;

public class UISound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    // singleton
    public static UISound instance;
    private void Awake() { instance = this; }

    public void PlaySound(AudioClip clip)
    {
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.PlayOneShot(clip);
    }
}
