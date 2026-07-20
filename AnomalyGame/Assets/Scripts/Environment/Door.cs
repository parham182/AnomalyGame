using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Door")]
    [SerializeField] private Transform pivot;
    [SerializeField] private Transform player;
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float openSpeed = 5f;
    [SerializeField] private Transform doorFront;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioClip closeClip;

    private Quaternion closedRotation;
    private Quaternion targetRotation;

    private bool isOpen;

    void Start()
    {
        closedRotation = pivot.localRotation;
    }

    public void Interact()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            Vector3 dir = player.position - doorFront.position;
            float dot = Vector3.Dot(doorFront.forward, dir);
            
            float angle = dot > 0 ? openAngle : -openAngle;

            targetRotation = closedRotation * Quaternion.Euler(0f, angle, 0f);

            if (audioSource && openClip)
            {
                audioSource.pitch = Random.Range(0.85f, 1.05f);
                audioSource.PlayOneShot(openClip);
            }

        }
        else
        {
            targetRotation = closedRotation;

            if (audioSource && closeClip)
            {
                audioSource.pitch = Random.Range(0.85f, 1.05f);
                audioSource.PlayOneShot(closeClip);
            }
        }
    }

    void Update()
    {
        pivot.localRotation = Quaternion.Slerp(
            pivot.localRotation,
            targetRotation,
            openSpeed * Time.deltaTime
        );
    }
}