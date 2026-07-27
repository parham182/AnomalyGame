using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Value")]
    [SerializeField] float doorOpenSpeed = 5f;
    [SerializeField] float targetAngle = -90f;
    [SerializeField] GameObject piviot;

    [Header("Sound")]
    [SerializeField] AudioClip opendoor;
    [SerializeField] AudioClip closedoor;

    [SerializeField] Collider doorCollider;

    private Quaternion closedRot;
    private Quaternion openRot;

    private bool isOpen;

    void Start()
    {
        closedRot = piviot.transform.rotation;
        openRot = Quaternion.Euler(0f, targetAngle, 0f);

        if (doorCollider == null)
            doorCollider = GetComponent<Collider>();
    }

    public void Interact()
    {
        isOpen = !isOpen;

        doorCollider.isTrigger = true;

        if (isOpen)
            SoundManager.instance.PlaySoundEffect(opendoor);
        else
            SoundManager.instance.PlaySoundEffect(closedoor);
    }

    void Update()
    {
        DoorHandler();
    }

    void DoorHandler()
    {
        Quaternion target = isOpen ? openRot : closedRot;

        piviot.transform.rotation = Quaternion.Slerp(
            piviot.transform.rotation,
            target,
            doorOpenSpeed * Time.deltaTime);


        if (Quaternion.Angle(piviot.transform.rotation, target) < 1f)
        {
            doorCollider.isTrigger = false;
        }
    }
}