using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("value")]
    [SerializeField] float doorOpenSpeed = 5f;
    [SerializeField] float targetAngle = -90f;
    [SerializeField] GameObject piviot;
    [Header("Sound")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip opendoor;
    [SerializeField] AudioClip closedoor;



    Quaternion closedRot;
    Quaternion openRot;

    bool isOpen;

    void Start()
    {
        closedRot = piviot.transform.rotation;
        openRot = Quaternion.Euler(0f, targetAngle, 0f);
    }

    public void Interact()
    {
        isOpen = !isOpen;

        audioSource.pitch = Random.Range(0.6f, 1f);

        if (isOpen)
            audioSource.PlayOneShot(opendoor);
        else
            audioSource.PlayOneShot(closedoor);
    }

    void Update()
    {
        DoorHandeler();
    }

    void DoorHandeler()
    {
        Quaternion target = isOpen ? openRot : closedRot;
        piviot.transform.rotation = Quaternion.Slerp(piviot.transform.rotation, target, doorOpenSpeed * Time.deltaTime);
    }
}
