using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource effectsAudioSource;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioClip clickSound;

    private void Start()
    {
        musicAudioSource.volume = SettingsManager.instance.musicVolume;
    }

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

    public IEnumerator StopMusicSlowly(float fadeDuration = 1f)
    {
        float startVolume = musicAudioSource.volume;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            musicAudioSource.volume = Mathf.Lerp(startVolume, 0f, elapsed / fadeDuration);
            yield return null;
        }

        musicAudioSource.volume = 0f;
        musicAudioSource.Stop();
    }
}
