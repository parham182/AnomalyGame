
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("value")]
    [SerializeField] float doorOpenSpeed = 5f;
    [SerializeField] float targetAngle = -90f;
    [SerializeField] GameObject piviot;
    [Header("Sound")]
    [SerializeField] AudioClip opendoor;
    [SerializeField] AudioClip closedoor;

    [SerializeField] Collider collider;


    public Quaternion closedRot;
    Quaternion openRot;

    bool isOpen;

    SoundManager soundManager;
    
    void Start()
    {
        closedRot = piviot.transform.rotation;
        openRot = Quaternion.Euler(0f, targetAngle, 0f);
        collider = GetComponent<Collider>();
    }

    public void Interact()
    {
        isOpen = !isOpen;

        if (isOpen)
            soundManager.PlaySoundEffect(opendoor);
        else
            soundManager.PlaySoundEffect(closedoor);
    }

    void Update()
    {
        DoorHandeler();
    }

    void DoorHandeler()
    {
        Quaternion target = isOpen ? openRot : closedRot;
        piviot.transform.rotation = Quaternion.Slerp(piviot.transform.rotation, target, doorOpenSpeed * Time.deltaTime);

        if (piviot.transform.rotation != closedRot)
        {
            collider.isTrigger = true;
        }
        else
        {
            collider.isTrigger = false;
        }
    }
}