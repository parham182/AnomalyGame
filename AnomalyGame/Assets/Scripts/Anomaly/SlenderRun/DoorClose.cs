using UnityEngine;

public class DoorClose : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float doorCloseSpeed = 5f;
    [SerializeField] private float targetAngle = -90f;
    [SerializeField] private Transform pivot;

    [Header("Sound")]
    [SerializeField] private AudioClip closeDoorSound;
    [SerializeField] private AudioSource audioSource;

    private Quaternion openRotation;
    private Quaternion closedRotation;

    private bool hasClosed = false;

    private void Start()
    {
        openRotation = pivot.rotation;
        closedRotation = Quaternion.Euler(0f, targetAngle, 0f);
    }

    private void Update()
    {
        if (!hasClosed && SlenderTrigger.instance.canCloseDoor)
        {
            hasClosed = true;

            audioSource.volume = SettingsManager.instance.soundFxVolume;
            audioSource.PlayOneShot(closeDoorSound);
        }

        if (hasClosed)
        {
            pivot.rotation = Quaternion.Slerp(
                pivot.rotation,
                closedRotation,
                doorCloseSpeed * Time.deltaTime);
        }
    }
}