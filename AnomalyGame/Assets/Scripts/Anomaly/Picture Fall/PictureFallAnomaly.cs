using UnityEngine;

public class PictureFallAnomaly : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fallClip;

    private bool hasTriggerd = false;
    private bool canTrigger = false;

    private void OnEnable()
    {
        canTrigger = true;
    }

    private void OnDisable()
    {
        canTrigger = false;
        hasTriggerd = false;
        animator.SetTrigger("Idle");
    }

    public void Trigger()
    {
        if (hasTriggerd || canTrigger == false) return;

        hasTriggerd = true;
        animator.SetTrigger("Fall");
    }

    public void PlayFallSound()
    {
        audioSource.volume = SettingsManager.instance.soundFxVolume;
        audioSource.PlayOneShot(fallClip);
    }
}
