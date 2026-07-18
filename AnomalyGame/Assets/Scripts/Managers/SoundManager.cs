using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource effectsAudioSource;
    [SerializeField] AudioClip clickSound;

    public static SoundManager instance;
    private void Awake() { instance = this; }

    public void PlaySoundEffect(AudioClip clip, float pitchChangeRatio = 0.05f)
    {
        effectsAudioSource.volume = SettingsManager.instance.soundFxVolume;
        effectsAudioSource.pitch = Random.Range(1 - pitchChangeRatio, 1 + pitchChangeRatio);
        effectsAudioSource.PlayOneShot(clip);
    }

    public void PlayClickSound()
    {
        PlaySoundEffect(clickSound);
    }
}
