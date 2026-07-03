using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour
{
    [SerializeField] InputActionReference flashlightToggel;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip onClip;
    [SerializeField] AudioClip offClip;
    
    public bool hasFlashLight = false;
    Light flashlight;
    bool isFlashLightOn;

    void OnEnable()
    {
        flashlightToggel.action.Enable();
    }
    void OnDisable()
    {
        flashlightToggel.action.Disable();
    }

    void Start()
    {
        flashlight = GetComponent<Light>();
        isFlashLightOn = false;
        flashlight.enabled = isFlashLightOn;
    }

    void Update()
    {
        if (hasFlashLight == false) return;

        if (flashlightToggel.action.WasCompletedThisFrame())
        {
            isFlashLightOn = !isFlashLightOn;
            flashlight.enabled = isFlashLightOn;

            audioSource.pitch = Random.Range(0.9f, 1.1f);
            if (isFlashLightOn) audioSource.PlayOneShot(onClip);
            else audioSource.PlayOneShot(offClip);
        }
    }
}
