using UnityEngine;

public class DoorKnock : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    int triggerAmount = 0;
    private bool canTrigger = false;

    private void OnEnable()
    {
        canTrigger = true;
    }

    private void OnDisable()
    {
        canTrigger = false;
        triggerAmount = 0;

        audioSource.Stop();
    }

    public void Trigger()
    {
        triggerAmount += 1;
        if (triggerAmount == 2 && canTrigger)
        {
            audioSource.Play();
        }
    }
}
