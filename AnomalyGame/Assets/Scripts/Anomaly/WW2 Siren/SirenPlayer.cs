using UnityEngine;

public class SirenPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

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
        audioSource.Stop();
    }

    public void PlaySiren()
    {
        if (canTrigger || hasTriggerd) return;

        hasTriggerd = true;
        audioSource.Play();
    }
}
