using UnityEngine;

public class DoorCloseAnomaly : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] float doorOpenSpeed = 5f;
    [SerializeField] float targetAngle = -90f;
    [SerializeField] GameObject piviot;

    [Header("Sound")]
    [SerializeField] AudioClip closeDoorSound;
    [SerializeField] AudioSource audioSource;

    public bool isOpen;

    private Quaternion closedRot;
    private Quaternion openRot;
    
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

        isOpen = true;
    }

    void Start()
    {
        closedRot = Quaternion.Euler(0f, targetAngle, 0f);;
        openRot = piviot.transform.rotation;
    }

    void Update()
    {
        DoorHandler();
    }

    public void Trigger() {
        if (hasTriggerd || canTrigger == false) return;

        hasTriggerd = true;
        isOpen = false;
        audioSource.volume = SettingsManager.instance.soundFxVolume;
        audioSource.PlayOneShot(closeDoorSound);
    }

    void DoorHandler()
    {
        Quaternion target = isOpen ? openRot : closedRot;

        piviot.transform.rotation = Quaternion.Slerp(
            piviot.transform.rotation,
            target,
            doorOpenSpeed * Time.deltaTime);
    }
}
